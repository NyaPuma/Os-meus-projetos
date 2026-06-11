<?php

namespace App\Http\Controllers;

use App\Models\Produto;
use Illuminate\Http\Request;

class ProdutoController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index(Request $request)
    {
        $query = Produto::query();

        // 1. Pesquisa de texto (Nome, Referência ou Código de Barras)
        if ($request->filled('search')) {
            $search = $request->input('search');
            $query->where(function ($q) use ($search) {
                $q->where('nome', 'like', "%{$search}%")
                    ->orWhere('referencia', 'like', "%{$search}%")
                    ->orWhere('codigo_barras', 'like', "%{$search}%");
            });
        }

        // 2. Filtro por Estado
        if ($request->filled('estado')) {
            $query->where('estado', $request->input('estado'));
        }

        // 3. Filtro por Alertas de Stock
        if ($request->filled('stock_status')) {
            if ($request->input('stock_status') === 'alerta') {
                $query->whereColumn('stock_atual', '<=', 'stock_minimo');
            } elseif ($request->input('stock_status') === 'com_stock') {
                $query->whereColumn('stock_atual', '>', 'stock_minimo');
            }
        }

        // 4. Ordenação Dinâmica Segura (Adicionado 'portes_envio' à lista permitida)
        $allowedColumns = ['id', 'nome', 'referencia', 'preco_venda', 'portes_envio', 'stock_atual', 'estado'];
        $orderBy = in_array($request->input('order_by'), $allowedColumns) ? $request->input('order_by') : 'nome';

        $direction = $request->input('direction') === 'desc' ? 'desc' : 'asc';

        // Executa a consulta
        $produtos = $query->orderBy($orderBy, $direction)->paginate(25);

        return view('produtos.index', compact('produtos'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        return view('produtos.create');
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        // Validar os dados do formulário
        $request->validate([
            'nome'          => 'required|max:255|unique:produtos,nome',
            'referencia'    => 'required|max:50|unique:produtos,referencia',
            'codigo_barras' => 'nullable|max:50|unique:produtos,codigo_barras',
            'preco_custo'   => 'required|numeric|min:0',
            'preco_venda'   => 'required|numeric|min:0',
            'portes_envio'  => 'required|numeric|min:0', // Validação adicionada
            'taxa_iva'      => 'required|integer|in:0,6,13,23',
            'stock_atual'   => 'required|integer|min:0',
            'stock_minimo'  => 'required|integer|min:0',
            'estado'        => 'in:ativo,inativo',
            'descricao'     => 'nullable',
        ]);

        // Gravar na base de dados
        Produto::create([
            'nome'          => $request->nome,
            'referencia'    => $request->referencia,
            'codigo_barras' => $request->codigo_barras,
            'preco_custo'   => $request->preco_custo,
            'preco_venda'   => $request->preco_venda,
            'portes_envio'  => $request->portes_envio, // Gravação adicionada
            'taxa_iva'      => $request->taxa_iva,
            'stock_atual'   => $request->stock_atual,
            'stock_minimo'  => $request->stock_minimo,
            'estado'        => $request->estado ?? 'ativo',
            'descricao'     => $request->descricao,
        ]);

        return redirect()
            ->route('produtos.index')
            ->with('success', 'Produto criado com sucesso!');
    }

    /**
     * Display the specified resource.
     */
    public function show($id)
    {
        $produto = Produto::findOrFail($id);
        return view('produtos.show', compact('produto'));
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit($id)
    {
        $produto = Produto::findOrFail($id);
        return view('produtos.edit', compact('produto'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, $id)
    {
        // Validar os dados do formulário ignorando o ID atual nas regras unique
        $request->validate([
            'nome'          => 'required|max:255|unique:produtos,nome,' . $id,
            'referencia'    => 'required|max:50|unique:produtos,referencia,' . $id,
            'codigo_barras' => 'nullable|max:50|unique:produtos,codigo_barras,' . $id,
            'preco_custo'   => 'required|numeric|min:0',
            'preco_venda'   => 'required|numeric|min:0',
            'portes_envio'  => 'required|numeric|min:0', // Validação adicionada
            'taxa_iva'      => 'required|integer|in:0,6,13,23',
            'stock_atual'   => 'required|integer|min:0',
            'stock_minimo'  => 'required|integer|min:0',
            'estado'        => 'in:ativo,inativo',
            'descricao'     => 'nullable',
        ]);

        // Alterar o produto
        $produto = Produto::findOrFail($id);
        $produto->nome          = $request->nome;
        $produto->referencia    = $request->referencia;
        $produto->codigo_barras = $request->codigo_barras;
        $produto->preco_custo   = $request->preco_custo;
        $produto->preco_venda   = $request->preco_venda;
        $produto->portes_envio  = $request->portes_envio; // Atribuição adicionada
        $produto->taxa_iva      = $request->taxa_iva;
        $produto->stock_atual   = $request->stock_atual;
        $produto->stock_minimo  = $request->stock_minimo;
        $produto->estado        = $request->estado ?? 'ativo';
        $produto->descricao     = $request->descricao;

        // Gravar a alteração
        $produto->save();

        return redirect()
            ->route('produtos.index')
            ->with('success', 'Produto alterado com sucesso!');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy($id)
    {
        // Procura o produto
        $produto = Produto::findOrFail($id);

        // Elimina o produto
        $produto->delete();

        return redirect()
            ->route('produtos.index')
            ->with('success', 'Produto eliminado com sucesso!');
    }
}
