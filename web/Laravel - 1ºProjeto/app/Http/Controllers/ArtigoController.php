<?php

namespace App\Http\Controllers;

use App\Models\Artigo;
use App\Models\Categoria;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Storage;

class ArtigoController extends Controller
{
    public function index(Request $request)
    {
        $query = Artigo::with('categoria');

        // 🔎 PESQUISA
        if ($request->filled('search')) {
            $search = $request->input('search');

            $query->where(function ($q) use ($search) {
                $q->where('descricao', 'like', "%{$search}%")
                    ->orWhere('caracteristicas', 'like', "%{$search}%");
            });
        }

        // 📦 FILTRO POR CATEGORIA
        if ($request->filled('categoria_id')) {
            $query->where('categoria_id', $request->input('categoria_id'));
        }

        // 📊 ORDENAÇÃO SEGURA
        $orderBy = $request->input('order_by', 'descricao');
        $direction = $request->input('direction', 'asc');

        if ($orderBy === 'categoria') {
            $query->join('categorias', 'artigos.categoria_id', '=', 'categorias.id')
                ->orderBy('categorias.categoria', $direction)
                ->select('artigos.*');
        } else {
            $allowedColumns = ['id', 'descricao', 'preco'];

            if (!in_array($orderBy, $allowedColumns)) {
                $orderBy = 'descricao';
            }

            $query->orderBy($orderBy, $direction);
        }

        $artigos = $query->paginate(25);

        return view('artigos.index', compact('artigos'));
    }

    public function create()
    {
        $categorias = Categoria::all();
        return view('artigos.create', compact('categorias'));
    }

    public function store(Request $request)
    {
        $request->validate([
            'descricao'       => 'required|max:100|string',
            'caracteristicas' => 'nullable|string',
            'preco'           => 'nullable|numeric',
            'foto'            => 'nullable|image',
            'categoria_id'    => 'required|exists:categorias,id'
        ]);

        $foto = null;

        if ($request->hasFile('foto')) {
            $foto = $request->file('foto')->store('artigos', 'public');
        }

        Artigo::create([
            'descricao'       => $request->descricao,
            'caracteristicas' => $request->caracteristicas,
            'preco'           => $request->preco,
            'foto'            => $foto,
            'categoria_id'    => $request->categoria_id,
        ]);

        return redirect()
            ->route('artigos.index')
            ->with('success', 'Artigo criado com sucesso!');;
    }

    public function show($id)
    {
        $artigo = Artigo::with('categoria')->findOrFail($id);
        return view('artigos.show', compact('artigo'));
    }

    public function edit($id)
    {
        $artigo = Artigo::findOrFail($id);
        $categorias = Categoria::all();

        return view('artigos.edit', compact('artigo', 'categorias'));
    }

    public function update(Request $request, $id)
    {
        $artigo = Artigo::findOrFail($id);

        $request->validate([
            'descricao'       => 'required|max:100|string',
            'caracteristicas' => 'nullable|string',
            'preco'           => 'nullable|numeric',
            'foto'            => 'nullable|image',
            'categoria_id'    => 'required|exists:categorias,id'
        ]);

        $foto = $artigo->foto;

        if ($request->hasFile('foto')) {

            // Apaga a foto antiga
            if ($artigo->foto && Storage::disk('public')->exists($artigo->foto)) {
                Storage::disk('public')->delete($artigo->foto);
            }

            // Guarda a nova foto
            $foto = $request->file('foto')->store('artigos', 'public');
        }

        $artigo->update([
            'descricao'       => $request->descricao,
            'caracteristicas' => $request->caracteristicas,
            'preco'           => $request->preco,
            'foto'            => $foto,
            'categoria_id'    => $request->categoria_id,
        ]);

        return redirect()
            ->route('artigos.index')
            ->with('success', 'Artigo alterado com sucesso!');
    }

    public function destroy($id)
    {
        $artigo = Artigo::findOrFail($id);

        if ($artigo->foto && Storage::disk('public')->exists($artigo->foto)) {
            Storage::disk('public')->delete($artigo->foto);
        }

        $artigo->delete();

        return redirect()
            ->route('artigos.index')
            ->with('success', 'Artigo eliminado com sucesso!');
    }
}
