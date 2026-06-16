<?php

namespace App\Http\Controllers;

use App\Models\Venda;
use App\Models\Cliente;
use App\Models\Apartamento;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class VendaController extends Controller
{
    /**
     * Listar todas as vendas com os respetivos clientes e apartamentos (com pesquisa e ordenação).
     */
    public function index(Request $request)
    {
        // 1. Capturar os parâmetros da pesquisa e ordenação
        $search = $request->input('search');
        $sortBy = $request->input('sort_by', 'id'); // 'id' é o padrão
        $order = $request->input('order', 'desc');   // 'desc' é o padrão

        // Security check: Validar se a ordenação introduzida é permitida
        $allowedSorts = ['id', 'data_venda', 'valor_venda'];
        if (!in_array($sortBy, $allowedSorts)) {
            $sortBy = 'id';
        }
        if (!in_array($order, ['asc', 'desc'])) {
            $order = 'desc';
        }

        // 2. Iniciar a Query com o Eager Loading (evita o problema N+1)
        $query = Venda::with(['cliente', 'apartamento']);

        // 3. Aplicar a lógica de pesquisa por texto (se houver termo de pesquisa)
        if (!empty($search)) {
            $query->where(function ($q) use ($search) {
                // Pesquisa pelo nome do Cliente
                $q->whereHas('cliente', function ($queryCliente) use ($search) {
                    $queryCliente->where('nome', 'like', '%' . $search . '%');
                })
                    // OU pesquisa pela referência ou morada do Apartamento
                    ->orWhereHas('apartamento', function ($queryApto) use ($search) {
                        $queryApto->where('referencia', 'like', '%' . $search . '%')
                            ->orWhere('morada', 'like', '%' . $search . '%');
                    });
            });
        }

        // 4. Aplicar a ordenação dinâmica
        $query->orderBy($sortBy, $order);

        // 5. Paginar mantendo os parâmetros na URL do paginate
        $vendas = $query->paginate(9)->withQueryString();

        return view('vendas.index', compact('vendas'));
    }

    /**
     * Mostrar o formulário para registar uma venda.
     */
    public function create()
    {
        $clientes = Cliente::all();

        // Passamos apenas os apartamentos "Disponíveis" para facilitar a escolha na UI
        $apartamentos = Apartamento::where('estado', 'Disponível')->get();

        return view('vendas.create', compact('clientes', 'apartamentos'));
    }

    /**
     * Guardar o registo da venda e atualizar o estado do apartamento.
     */
    public function store(Request $request)
    {
        // CORREÇÃO: Guardar o retorno da validação em $data
        $data = $request->validate([
            'cliente_id' => 'required|exists:clientes,id',
            'apartamento_id' => 'required|exists:apartamentos,id',
            'data_venda' => 'required|date',
            'valor_venda' => 'required|numeric|min:0',
            'observacoes' => 'nullable|string',
        ]);

        // Procurar o apartamento escolhido
        $apartamento = Apartamento::findOrFail($request->apartamento_id);

        // Requisito de Segurança: Impedir a venda se já estiver vendido
        if ($apartamento->estado === 'Vendido') {
            return redirect()->back()
                ->withInput()
                ->withErrors(['apartamento_id' => 'Este apartamento já foi vendido e não pode ser comercializado novamente.']);
        }

        // Usamos uma Transação DB para garantir consistência total
        DB::transaction(function () use ($data, $apartamento) {
            // 1. Criar a venda de forma segura com os dados filtrados
            Venda::create($data);

            // 2. Requisito: Atualizar o estado do apartamento para "Vendido"
            $apartamento->update(['estado' => 'Vendido']);
        });

        return redirect()->route('vendas.index')
            ->with('success', 'Venda registada com sucesso e estado do imóvel atualizado!');
    }

    /**
     * Consultar os detalhes de uma venda.
     */
    public function show(Venda $venda)
    {
        $venda->load(['cliente', 'apartamento']);
        return view('vendas.show', compact('venda'));
    }

    /**
     * Mostrar formulário de edição da venda.
     */
    public function edit(Venda $venda)
    {
        $clientes = Cliente::all();

        // Para a edição, o apartamento atual da venda deve aparecer na lista,
        // juntamente com os restantes que estão disponíveis.
        $apartamentos = Apartamento::where('estado', 'Disponível')
            ->orWhere('id', $venda->apartamento_id)
            ->get();

        return view('vendas.edit', compact('venda', 'clientes', 'apartamentos'));
    }

    /**
     * Atualizar a venda e gerir os estados dos apartamentos envolvidos.
     */
    public function update(Request $request, Venda $venda)
    {
        // CORREÇÃO: Guardar o retorno da validação em $data
        $data = $request->validate([
            'cliente_id' => 'required|exists:clientes,id',
            'apartamento_id' => 'required|exists:apartamentos,id',
            'data_venda' => 'required|date',
            'valor_venda' => 'required|numeric|min:0',
            'observacoes' => 'nullable|string',
        ]);

        DB::transaction(function () use ($data, $venda) {
            // Se o apartamento mudou nesta edição, precisamos de libertar o antigo
            if ($venda->apartamento_id != $data['apartamento_id']) {
                // Libertar o antigo apartamento
                Apartamento::where('id', $venda->apartamento_id)->update(['estado' => 'Disponível']);

                // Bloquear o novo apartamento
                $novoApartamento = Apartamento::findOrFail($data['apartamento_id']);
                if ($novoApartamento->estado === 'Vendido') {
                    abort(422, 'O novo apartamento selecionado já está vendido.');
                }
                $novoApartamento->update(['estado' => 'Vendido']);
            }

            // Atualizar os dados da venda com segurança
            $venda->update($data);
        });

        return redirect()->route('vendas.index')
            ->with('success', 'Registo de venda atualizado com sucesso!');
    }

    /**
     * Cancelar/Apagar uma venda.
     */
    public function destroy(Venda $venda)
    {
        DB::transaction(function () use ($venda) {
            // O apartamento associado volta a ficar disponível para venda
            Apartamento::where('id', $venda->apartamento_id)->update(['estado' => 'Disponível']);

            // Apaga o registo da venda
            $venda->delete();
        });

        return redirect()->route('vendas.index')
            ->with('success', 'Venda eliminada. O apartamento voltou ao estado Disponível.');
    }
}
