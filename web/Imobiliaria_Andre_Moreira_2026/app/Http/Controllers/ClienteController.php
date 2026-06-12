<?php

namespace App\Http\Controllers;

use App\Models\Cliente;
use Illuminate\Http\Request;

class ClienteController extends Controller
{
    /**
     * Listar todos os clientes.
     */
    public function index(Request $request)
    {
        $query = Cliente::query();

        // SEARCH
        if ($request->filled('search')) {
            $search = $request->input('search');

            $query->where(function ($q) use ($search) {
                $q->where('nome', 'like', "%{$search}%")
                    ->orWhere('nif', 'like', "%{$search}%")
                    ->orWhere('email', 'like', "%{$search}%")
                    ->orWhere('morada', 'like', "%{$search}%");
            });
        }

        // SORT
        $sortBy = $request->input('sort_by', 'id');
        $order  = $request->input('order', 'asc');

        $allowedSorts = ['id', 'nome', 'nif'];

        if (in_array($sortBy, $allowedSorts)) {
            $query->orderBy($sortBy, $order);
        }

        $clientes = $query->paginate(9)->withQueryString();

        return view('clientes.index', compact('clientes'));
    }

    /**
     * Mostrar o formulário para criar um novo cliente.
     */
    public function create()
    {
        return view('clientes.create');
    }

    /**
     * Guardar o novo cliente na base de dados (com validação).
     */
    public function store(Request $request)
    {
        // CORREÇÃO: Capturar o array apenas com os dados validados (ignora o _token)
        $data = $request->validate([
            'nome' => 'required|string|max:255',
            'email' => 'required|email|unique:clientes,email',
            'telefone' => 'required|string|max:20',
            'morada' => 'required|string|max:255',
            'nif' => 'required|string|size:9|unique:clientes,nif',
        ], [
            'email.unique' => 'Este e-mail já está registado.',
            'nif.unique' => 'Este NIF já está registado.',
            'nif.size' => 'O NIF deve ter exatamente 9 dígitos.',
        ]);

        // Gravação segura usando apenas as chaves validadas
        Cliente::create($data);

        return redirect()->route('clientes.index')
            ->with('success', 'Cliente criado com sucesso!');
    }

    /**
     * Consultar os detalhes de um cliente específico.
     */
    public function show(Cliente $cliente)
    {
        // Carrega também as vendas do cliente para a vista de detalhes
        $cliente->load('vendas.apartamento');
        return view('clientes.show', compact('cliente'));
    }

    /**
     * Mostrar o formulário para editar um cliente existente.
     */
    public function edit(Cliente $cliente)
    {
        return view('clientes.edit', compact('cliente'));
    }

    /**
     * Atualizar os dados do cliente na base de dados (com validação).
     */
    public function update(Request $request, Cliente $cliente)
    {
        // CORREÇÃO: Capturar apenas os dados validados (ignora _token e _method)
        $data = $request->validate([
            'nome' => 'required|string|max:255',
            'email' => 'required|email|unique:clientes,email,' . $cliente->id,
            'telefone' => 'required|string|max:20',
            'morada' => 'required|string|max:255',
            'nif' => 'required|string|size:9|unique:clientes,nif,' . $cliente->id,
        ]);

        // Atualização segura
        $cliente->update($data);

        return redirect()->route('clientes.index')
            ->with('success', 'Cliente atualizado com sucesso!');
    }

    /**
     * Apagar um cliente da base de dados.
     */
    public function destroy(Cliente $cliente)
    {
        $cliente->delete();

        return redirect()->route('clientes.index')
            ->with('success', 'Cliente apagado com sucesso!');
    }
}
