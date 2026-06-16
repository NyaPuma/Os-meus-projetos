<?php

namespace App\Http\Controllers;

use App\Models\Cliente;
use Illuminate\Http\Request;

class ClienteController extends Controller
{
    // 1. Listar todos os clientes com suporte a pesquisa e ordenação (Index)
    public function index(Request $request)
    {
        // Iniciamos a construção da query através do construtor do Eloquent
        $query = Cliente::query();

        // 1. Aplicar a pesquisa textual (se existir e não estiver vazia)
        if ($request->filled('search')) {
            $search = $request->input('search');

            // Agrupamos os 'orWhere' dentro de uma closure para não quebrar a lógica de outros filtros futuros
            $query->where(function ($q) use ($search) {
                $q->where('nome', 'like', "%{$search}%")
                  ->orWhere('email', 'like', "%{$search}%")
                  ->orWhere('telefone', 'like', "%{$search}%")
                  ->orWhere('nif', 'like', "%{$search}%");
            });
        }

        // 2. Definir os parâmetros de ordenação (com valores por omissão)
        $sortBy = $request->input('sort_by', 'nome'); // Ordena por 'nome' por omissão
        $order = $request->input('order', 'asc');     // Ordem crescente por omissão

        // Lista de campos e direções permitidos para evitar SQL Injection estrutural
        $allowedSorts = ['id', 'nome'];
        $allowedOrders = ['asc', 'desc'];

        if (!in_array($sortBy, $allowedSorts)) {
            $sortBy = 'nome';
        }

        if (!in_array($order, $allowedOrders)) {
            $order = 'asc';
        }

        // Executa a query aplicando a ordenação validada
        $clientes = $query->orderBy($sortBy, $order)->paginate(10)->withQueryString();

        // Retorna a view enviando a coleção de clientes filtrada e ordenada
        return view('clientes.index', compact('clientes'));
    }

    // 2. Mostrar o formulário de criação (Create)
    public function create()
    {
        return view('clientes.create');
    }

    // 3. Gravar o novo cliente na Base de Dados (Store)
    public function store(Request $request)
    {
        // Validação dos dados recebidos do formulário
        $validated = $request->validate([
            'nome' => 'required|string|max:255',
            'email' => 'required|email|unique:clientes,email',
            'telefone' => 'required|string|max:20',
            'morada' => 'required|string|max:255',
            'nif' => 'required|string|size:9|unique:clientes,nif',
        ]);

        Cliente::create($validated);

        // Redireciona com mensagem flash de sucesso
        return redirect()->route('clientes.index')
            ->with('success', 'Cliente registado com sucesso!');
    }

    // 4. Mostrar os detalhes de um cliente específico (Show)
    public function show(Cliente $cliente)
    {
        return view('clientes.show', compact('cliente'));
    }

    // 5. Mostrar o formulário de edição (Edit)
    public function edit(Cliente $cliente)
    {
        return view('clientes.edit', compact('cliente'));
    }

    // 6. Atualizar os dados do cliente (Update)
    public function update(Request $request, Cliente $cliente)
    {
        // Validação (ignorando o ID do próprio cliente no teste de campos únicos)
        $validated = $request->validate([
            'nome' => 'required|string|max:255',
            'email' => 'required|email|unique:clientes,email,' . $cliente->id,
            'telefone' => 'required|string|max:20',
            'morada' => 'required|string|max:255',
            'nif' => 'required|string|size:9|unique:clientes,nif,' . $cliente->id,
        ]);

        $cliente->update($validated);

        return redirect()->route('clientes.index')
            ->with('success', 'Dados do cliente atualizados com sucesso!');
    }

    // 7. Apagar um cliente (Destroy)
    public function destroy(Cliente $cliente)
    {
        $cliente->delete();

        return redirect()->route('clientes.index')
            ->with('success', 'Cliente removido do sistema com sucesso!');
    }
}
