<?php

namespace App\Http\Controllers;

use App\Models\Viatura;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Storage;

class ViaturaController extends Controller
{
    // 1. Listar viaturas com filtros de pesquisa, ordenação e paginação (Index)
    public function index(Request $request)
    {
        $query = Viatura::query();

        // Funcionalidade: Pesquisar por marca, modelo ou matrícula
        if ($request->filled('search')) {
            $search = $request->input('search');
            $query->where(function($q) use ($search) {
                $q->where('marca', 'like', "%{$search}%")
                  ->orWhere('modelo', 'like', "%{$search}%")
                  ->orWhere('matricula', 'like', "%{$search}%");
            });
        }

        // Funcionalidade: Ordenar por ID, marca, modelo, ano ou preço
        $sortBy = $request->input('sort_by', 'id');
        $allowedSorts = ['id', 'marca', 'modelo', 'ano', 'preco'];
        if (!in_array($sortBy, $allowedSorts)) {
            $sortBy = 'id';
        }

        $order = $request->input('order', 'asc');
        $order = ($order === 'desc') ? 'desc' : 'asc';

        // Aplica a ordenação e define o limite máximo de 10 automóveis por página
        // O método appends() anexa os parâmetros da pesquisa aos links de paginação
        $viaturas = $query->orderBy($sortBy, $order)
                          ->paginate(10)
                          ->appends($request->all());

        return view('viaturas.index', compact('viaturas', 'sortBy', 'order'));
    }

    // 2. Mostrar o formulário de criação
    public function create()
    {
        return view('viaturas.create');
    }

    // 3. Gravar a nova viatura (com Upload de Imagem)
    public function store(Request $request)
    {
        // Validação de formulários estrita
        $validated = $request->validate([
            'marca' => 'required|string|max:255',
            'modelo' => 'required|string|max:255',
            'matricula' => 'required|string|max:20|unique:viaturas,matricula',
            'ano' => 'required|integer|min:1900|max:' . (date('Y') + 1),
            'quilometros' => 'required|integer|min:0',
            'preco' => 'required|numeric|min:0',
            'foto' => 'nullable|image|mimes:jpeg,png,jpg,webp|max:2048', // Validação da imagem
            'estado' => 'required|in:disponível,vendido',
        ]);

        // Upload de fotografia da viatura
        if ($request->hasFile('foto')) {
            $path = $request->file('foto')->store('viaturas', 'public');
            $validated['foto'] = $path;
        }

        Viatura::create($validated);

        return redirect()->route('viaturas.index')
            ->with('success', 'Viatura registada com sucesso!');
    }

    // 4. Visualizar uma viatura específica
    public function show(Viatura $viatura)
    {
        return view('viaturas.show', compact('viatura'));
    }

    // 5. Mostrar o formulário de edição
    public function edit(Viatura $viatura)
    {
        return view('viaturas.edit', compact('viatura'));
    }

    // 6. Atualizar os dados da viatura (Garantindo a gestão de imagens antiga)
    public function update(Request $request, Viatura $viatura)
    {
        $validated = $request->validate([
            'marca' => 'required|string|max:255',
            'modelo' => 'required|string|max:255',
            'matricula' => 'required|string|max:20|unique:viaturas,matricula,' . $viatura->id,
            'ano' => 'required|integer|min:1900|max:' . (date('Y') + 1),
            'quilometros' => 'required|integer|min:0',
            'preco' => 'required|numeric|min:0',
            'foto' => 'nullable|image|mimes:jpeg,png,jpg,webp|max:2048',
            'estado' => 'required|in:disponível,vendido',
        ]);

        // Se uma nova foto for submetida, substitui a antiga
        if ($request->hasFile('foto')) {
            if ($viatura->foto) {
                Storage::disk('public')->delete($viatura->foto);
            }
            $path = $request->file('foto')->store('viaturas', 'public');
            $validated['foto'] = $path;
        }

        $viatura->update($validated);

        return redirect()->route('viaturas.index')
            ->with('success', 'Viatura atualizada com sucesso!');
    }

    // 7. Apagar a viatura e o seu ficheiro de imagem do disco
    public function destroy(Viatura $viatura)
    {
        if ($viatura->foto) {
            Storage::disk('public')->delete($viatura->foto);
        }

        $viatura->delete();

        return redirect()->route('viaturas.index')
            ->with('success', 'Viatura eliminada do sistema!');
    }
}
