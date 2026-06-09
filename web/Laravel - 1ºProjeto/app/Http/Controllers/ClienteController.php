<?php

namespace App\Http\Controllers;

use App\Models\Cliente;
use Illuminate\Http\Request;

class ClienteController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index(Request $request)
    {
        //
        $query = Cliente::query();

        // 1. Filtro de pesquisa de texto
        if ($request->filled('search')) {
            $search = $request->input('search');
            $query->where(function ($q) use ($search) {
                $q->where('nome', 'like', "%{$search}%")
                    ->orWhere('email', 'like', "%{$search}%");
            });
        }

        // 2. Validação e aplicação da ordenação dinâmica
        $allowedColumns = ['id', 'nome', 'email', 'telefone'];
        $orderBy = in_array($request->input('order_by'), $allowedColumns) ? $request->input('order_by') : 'nome';

        $direction = $request->input('direction') === 'desc' ? 'desc' : 'asc';

        // Obtém os dados ordenados
        $clientes = $query->orderBy($orderBy, $direction)->get(); // ou ->paginate(10);

        return view('clientes.index', compact('clientes'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        //


        return view('clientes.create');
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        // Validar os dados do formulario
        $request->validate([
            'nome'       => 'required|max:100',
            'morada'     => 'nullable|max:100',
            'localidade' => 'nullable|max:30',
            'email'      => 'required|email|unique:clientes,email',
            'telefone'   => 'nullable|max:15',
        ]);

        // Gravar na base de dados
        Cliente::create([
            'nome'       => $request->nome,
            'morada'     => $request->morada,
            'localidade' => $request->localidade,
            'email'      => $request->email,
            'telefone'   => $request->telefone,
        ]);

        return redirect()
            ->route('clientes.index')
            ->with('success', 'Cliente criado com sucesso!');
    }

    /**
     * Display the specified resource.
     */
    public function show($id)
    {
        //
        $cliente = Cliente::findorFail($id);
        return view('clientes.show', compact('cliente'));
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit($id)
    {
        //
        $cliente = Cliente::findorFail($id);
        return view('clientes.edit', compact('cliente'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, $id)
    {
        // Alterar o cliente
        $cliente = Cliente::findorFail($id);
        $cliente->nome       = $request->nome;
        $cliente->morada     = $request->morada;
        $cliente->localidade = $request->localidade;
        $cliente->email      = $request->email;
        $cliente->telefone   = $request->telefone;

        // Gravar a alteração
        $cliente->save();

        // Redirecionar para o index
        return redirect()
            ->route('clientes.index')
            ->with('success', 'Cliente alterado com sucesso!');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy($id)
    {
        // Procura cliente
        $cliente = Cliente::findorFail($id);

        // Elimina o cliente
        $cliente->delete();

        // Redirecionar para o index
        return redirect()
            ->route('clientes.index')
            ->with('success', 'Cliente eliminado com sucesso!');
    }
}
