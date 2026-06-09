<?php

namespace App\Http\Controllers;

use App\Models\Fornecedor;
use Illuminate\Http\Request;

class FornecedorController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index(Request $request)
    {
        $query = Fornecedor::query();

        // 1. Pesquisa de texto (Nome, NIF ou Email)
        if ($request->filled('search')) {
            $search = $request->input('search');
            $query->where(function ($q) use ($search) {
                $q->where('nome', 'like', "%{$search}%")
                    ->orWhere('nif', 'like', "%{$search}%")
                    ->orWhere('email', 'like', "%{$search}%");
            });
        }

        // 2. Filtro por Estado
        if ($request->filled('estado')) {
            $query->where('estado', $request->input('estado'));
        }

        // 3. Filtro por País
        if ($request->filled('pais')) {
            $query->where('pais', $request->input('pais'));
        }

        // 4. Ordenação Dinâmica Segura
        $allowedColumns = ['id', 'nome', 'nif', 'email', 'telefone', 'estado'];
        $orderBy = in_array($request->input('order_by'), $allowedColumns) ? $request->input('order_by') : 'nome';

        $direction = $request->input('direction') === 'desc' ? 'desc' : 'asc';

        // Executa a consulta
        $fornecedores = $query->orderBy($orderBy, $direction)->get(); // ou ->paginate(10);

        return view('fornecedores.index', compact('fornecedores'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        return view('fornecedores.create');
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        // Validar os dados do formulário
        $request->validate([
            'nome'          => 'required|max:100',
            'nif'           => 'nullable|max:20|unique:fornecedors,nif',
            'morada'        => 'nullable|max:255',
            'codigo_postal' => 'nullable|max:20',
            'localidade'    => 'nullable|max:100',
            'pais'          => 'nullable|max:100',
            'email'         => 'required|email|unique:fornecedors,email',
            'telefone'      => 'nullable|max:15',
            'website'       => 'nullable|url|max:255',
            'contacto'      => 'nullable|max:100',
            'estado'        => 'in:ativo,inativo',
            'observacoes'   => 'nullable',
        ]);

        // Gravar na base de dados
        Fornecedor::create([
            'nome'          => $request->nome,
            'nif'           => $request->nif,
            'morada'        => $request->morada,
            'codigo_postal' => $request->codigo_postal,
            'localidade'    => $request->localidade,
            'pais'          => $request->pais ?? 'Portugal',
            'email'         => $request->email,
            'telefone'      => $request->telefone,
            'website'       => $request->website,
            'contacto'      => $request->contacto,
            'estado'        => $request->estado ?? 'ativo',
            'observacoes'   => $request->observacoes,
        ]);

        return redirect()
            ->route('fornecedores.index')
            ->with('success', 'Fornecedor criado com sucesso!');
    }

    /**
     * Display the specified resource.
     */
    public function show($id)
    {
        $fornecedor = Fornecedor::findOrFail($id);
        return view('fornecedores.show', compact('fornecedor'));
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit($id)
    {
        $fornecedor = Fornecedor::findOrFail($id);
        return view('fornecedores.edit', compact('fornecedor'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, $id)
    {
        // Validar os dados do formulário
        $request->validate([
            'nome'          => 'required|max:100',
            'nif'           => 'nullable|max:20|unique:fornecedors,nif,' . $id,
            'morada'        => 'nullable|max:255',
            'codigo_postal' => 'nullable|max:20',
            'localidade'    => 'nullable|max:100',
            'pais'          => 'nullable|max:100',
            'email'         => 'required|email|unique:fornecedors,email,' . $id,
            'telefone'      => 'nullable|max:15',
            'website'       => 'nullable|url|max:255',
            'contacto'      => 'nullable|max:100',
            'estado'        => 'in:ativo,inativo',
            'observacoes'   => 'nullable',
        ]);

        // Alterar o fornecedor
        $fornecedor = Fornecedor::findOrFail($id);
        $fornecedor->nome          = $request->nome;
        $fornecedor->nif           = $request->nif;
        $fornecedor->morada        = $request->morada;
        $fornecedor->codigo_postal = $request->codigo_postal;
        $fornecedor->localidade    = $request->localidade;
        $fornecedor->pais          = $request->pais ?? 'Portugal';
        $fornecedor->email         = $request->email;
        $fornecedor->telefone      = $request->telefone;
        $fornecedor->website       = $request->website;
        $fornecedor->contacto      = $request->contacto;
        $fornecedor->estado        = $request->estado ?? 'ativo';
        $fornecedor->observacoes   = $request->observacoes;

        // Gravar a alteração
        $fornecedor->save();

        return redirect()
            ->route('fornecedores.index')
            ->with('success', 'Fornecedor alteredo com sucesso!');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy($id)
    {
        // Procura fornecedor
        $fornecedor = Fornecedor::findOrFail($id);

        // Elimina o fornecedor
        $fornecedor->delete();

        return redirect()
            ->route('fornecedores.index')
            ->with('success', 'Fornecedor eliminado com sucesso!');
    }
}
