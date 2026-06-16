<?php

namespace App\Http\Controllers;

use App\Models\Apartamento;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Storage;

class ApartamentoController extends Controller
{
    /**
     * Listar apartamentos com suporte a pesquisa e ordenação.
     */
    public function index(Request $request)
    {
        $query = Apartamento::query();

        // Pesquisa por referência, tipologia ou morada
        if ($request->filled('search')) {
            $search = $request->input('search');

            $query->where(function ($q) use ($search) {
                $q->where('referencia', 'like', "%{$search}%")
                    ->orWhere('tipologia', 'like', "%{$search}%")
                    ->orWhere('morada', 'like', "%{$search}%");
            });
        }

        // NOVO: Filtro por Estado (Disponível / Vendido)
        if ($request->filled('estado')) {
            $query->where('estado', $request->input('estado'));
        }

        // Ordenação
        $sortBy = $request->input('sort_by', 'id');
        $order = $request->input('order', 'asc');

        $allowedSorts = ['id', 'tipologia', 'area', 'preco'];

        if (in_array($sortBy, $allowedSorts)) {
            $query->orderBy($sortBy, $order);
        }

        $apartamentos = $query->paginate(9)->withQueryString();

        return view('apartamentos.index', compact('apartamentos'));
    }

    /**
     * Formulário de criação.
     */
    public function create()
    {
        return view('apartamentos.create');
    }

    /**
     * Guardar apartamento.
     * NOTA: referência é gerada automaticamente no Model.
     */
    public function store(Request $request)
    {
        $data = $request->validate([
            'tipologia' => 'required|string|max:10',
            'morada' => 'required|string|max:255',
            'area' => 'required|integer|min:1',
            'preco' => 'required|numeric|min:0',
            'fotografia' => 'nullable|image|mimes:jpeg,png,jpg,webp|max:2048',
            'estado' => 'required|in:Disponível,Vendido',
        ]);

        if ($request->hasFile('fotografia')) {
            $path = $request->file('fotografia')->store('apartamentos', 'public');
            $data['fotografia'] = $path;
        }

        Apartamento::create($data);

        return redirect()
            ->route('apartamentos.index')
            ->with('success', 'Apartamento registado com sucesso!');
    }

    /**
     * Mostrar detalhes.
     */
    public function show(Apartamento $apartamento)
    {
        $apartamento->load('venda.cliente');

        return view('apartamentos.show', compact('apartamento'));
    }

    /**
     * Formulário de edição.
     */
    public function edit(Apartamento $apartamento)
    {
        return view('apartamentos.edit', compact('apartamento'));
    }

    /**
     * Atualizar apartamento.
     */
    public function update(Request $request, Apartamento $apartamento)
    {
        $data = $request->validate([
            'tipologia' => 'required|string|max:10',
            'morada' => 'required|string|max:255',
            'area' => 'required|integer|min:1',
            'preco' => 'required|numeric|min:0',
            'fotografia' => 'nullable|image|mimes:jpeg,png,jpg,webp|max:2048',
            'estado' => 'required|in:Disponível,Vendido',
        ]);

        // Se o utilizador enviou uma NOVA fotografia
        if ($request->hasFile('fotografia')) {

            // 1. Verifica se já existia uma fotografia antiga guardada e se o ficheiro existe no disco
            if ($apartamento->fotografia && Storage::disk('public')->exists($apartamento->fotografia)) {
                // Elimina a fotografia anterior do armazenamento para poupar espaço
                Storage::disk('public')->delete($apartamento->fotografia);
            }

            // 2. Guarda a nova fotografia
            $path = $request->file('fotografia')->store('apartamentos', 'public');
            $data['fotografia'] = $path;
        }

        $apartamento->update($data);

        return redirect()
            ->route('apartamentos.index')
            ->with('success', 'Apartamento atualizado com sucesso!');
    }

    /**
     * Eliminar apartamento.
     */
    public function destroy(Apartamento $apartamento)
    {
        // Garante que ao apagar o apartamento, a fotografia também sai do disco
        if ($apartamento->fotografia && Storage::disk('public')->exists($apartamento->fotografia)) {
            Storage::disk('public')->delete($apartamento->fotografia);
        }

        $apartamento->delete();

        return redirect()
            ->route('apartamentos.index')
            ->with('success', 'Apartamento removido com sucesso!');
    }
}
