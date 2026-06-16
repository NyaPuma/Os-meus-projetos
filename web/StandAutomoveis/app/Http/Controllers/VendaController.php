<?php

namespace App\Http\Controllers;

use App\Models\Venda;
use App\Models\Cliente;
use App\Models\Viatura;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class VendaController extends Controller
{
    // 1. Listar todas as vendas com suporte a pesquisa, ordenação e paginação (Index)
    public function index(Request $request)
    {
        // Carrega as relações de cliente e viatura juntas para evitar o problema de N+1 queries
        $query = Venda::with(['cliente', 'viatura']);

        // 1. Aplicar a pesquisa textual cruzada (Vendas, Clientes e Viaturas)
        if ($request->filled('search')) {
            $search = $request->input('search');

            $query->where(function ($q) use ($search) {
                // Permite pesquisar pelo ID do contrato (limpa o '#' caso o utilizador digite ex: #0004)
                $cleanSearch = ltrim($search, '#');
                if (is_numeric($cleanSearch)) {
                    $q->where('id', intval($cleanSearch));
                }

                // Pesquisa nos dados do Cliente relacionado
                $q->orWhereHas('cliente', function ($qCliente) use ($search) {
                    $qCliente->where('nome', 'like', "%{$search}%")
                             ->orWhere('nif', 'like', "%{$search}%");
                });

                // Pesquisa nos dados da Viatura relacionada
                $q->orWhereHas('viatura', function ($qViatura) use ($search) {
                    $qViatura->where('marca', 'like', "%{$search}%")
                             ->orWhere('modelo', 'like', "%{$search}%")
                             ->orWhere('matricula', 'like', "%{$search}%");
                });
            });
        }

        // 2. Definir os parâmetros de ordenação (com valores por omissão da view)
        $sortBy = $request->input('sort_by', 'data_venda'); // Ordena por data por omissão
        $order = $request->input('order', 'desc');         // Mais recentes primeiro por omissão

        // Lista de campos e direções permitidos para evitar SQL Injection estrutural
        $allowedSorts = ['id', 'data_venda', 'valor_venda'];
        $allowedOrders = ['asc', 'desc'];

        if (!in_array($sortBy, $allowedSorts)) {
            $sortBy = 'data_venda';
        }

        if (!in_array($order, $allowedOrders)) {
            $order = 'desc';
        }

        // ALTERADO: Substituído ->get() por ->paginate(10)->withQueryString()
        $vendas = $query->orderBy($sortBy, $order)->paginate(10)->withQueryString();

        return view('vendas.index', compact('vendas'));
    }

    // 2. Mostrar formulário de criação (Apenas com viaturas disponíveis!)
    public function create()
    {
        $clientes = Cliente::all();
        // Segurança e UX: Só enviamos para o formulário as viaturas que podem ser vendidas
        $viaturas = Viatura::where('estado', 'disponível')->paginate(10)->withQueryString();

        return view('vendas.create', compact('clientes', 'viaturas'));
    }

    // 3. Gravar a venda e atualizar o estado da viatura (Uso de Database Transaction)
    public function store(Request $request)
    {
        $validated = $request->validate([
            'cliente_id' => 'required|exists:clientes,id',
            'viatura_id' => 'required|exists:viaturas,id',
            'data_venda' => 'required|date|before_or_equal:today',
            'valor_venda' => 'required|numeric|min:0',
            'observacoes' => 'nullable|string',
        ]);

        // Regra de Ouro: Verificar se a viatura não foi vendida entretanto
        $viatura = Viatura::findOrFail($request->viatura_id);
        if ($viatura->estado === 'vendido') {
            return redirect()->back()
                ->withInput()
                ->withErrors(['viatura_id' => 'Esta viatura já foi vendida e não está disponível!']);
        }

        // Executa as duas operações juntas. Se uma falhar, nenhuma é gravada.
        DB::transaction(function () use ($validated, $viatura) {
            // Criar o registo da venda
            Venda::create($validated);

            // Atualizar o estado da viatura para 'vendido'
            $viatura->update(['estado' => 'vendido']);
        });

        return redirect()->route('vendas.index')
            ->with('success', 'Venda registada com sucesso e viatura atualizada!');
    }

    // 4. Mostrar detalhes de uma venda específica
    public function show(Venda $venda)
    {
        return view('vendas.show', compact('venda'));
    }

    // 5. Mostrar formulário de edição
    public function edit(Venda $venda)
    {
        $clientes = Cliente::all();

        // Para o formulário de edição, precisamos de listar as viaturas disponíveis
        // MAIS a viatura que já está associada a esta venda específica.
        $viaturas = Viatura::where('estado', 'disponível')
            ->orWhere('id', $venda->viatura_id)
            ->get();

        return view('vendas.edit', compact('venda', 'clientes', 'viaturas'));
    }

    // 6. Atualizar a venda (Gerindo a troca de viaturas, se aplicável)
    public function update(Request $request, Venda $venda)
    {
        $validated = $request->validate([
            'cliente_id' => 'required|exists:clientes,id',
            'viatura_id' => 'required|exists:viaturas,id',
            'data_venda' => 'required|date|before_or_equal:today',
            'valor_venda' => 'required|numeric|min:0',
            'observacoes' => 'nullable|string',
        ]);

        // Se o utilizador alterou a viatura desta venda
        if ($venda->viatura_id != $request->viatura_id) {

            // 1. Verificar se a NOVA viatura está disponível
            $novaViatura = Viatura::findOrFail($request->viatura_id);
            if ($novaViatura->estado === 'vendido') {
                return redirect()->back()
                    ->withInput()
                    ->withErrors(['viatura_id' => 'A nova viatura selecionada já está vendida!']);
            }

            DB::transaction(function () use ($validated, $venda, $novaViatura) {
                // 2. Libertar a viatura VELHA (volta a estar disponível)
                $venda->viatura->update(['estado' => 'disponível']);

                // 3. Atualizar os dados da venda
                $venda->update($validated);

                // 4. Bloquear a NOVA viatura
                $novaViatura->update(['estado' => 'vendido']);
            });
        } else {
            // Se a viatura se manteve a mesma, apenas atualiza os restantes dados
            $venda->update($validated);
        }

        return redirect()->route('vendas.index')
            ->with('success', 'Registo de venda atualizado com sucesso!');
    }

    // 7. Cancelar/Apagar a venda (Liberta a viatura novamente)
    public function destroy(Venda $venda)
    {
        DB::transaction(function () use ($venda) {
            // Antes de apagar a venda, a viatura associada volta a ficar disponível no stand
            $venda->viatura->update(['estado' => 'disponível']);

            // Apaga o registo da venda
            $venda->delete();
        });

        return redirect()->route('vendas.index')
            ->with('success', 'Venda cancelada. A viatura está novamente disponível para venda.');
    }
}
