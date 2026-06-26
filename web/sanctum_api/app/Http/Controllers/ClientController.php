<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Client;

class ClientController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $clients = Client::all();
        return response()->json($clients);
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        // Verifica se o token tem permissão para criar
        if (!$request->user()->tokenCan('create')) {
            return response()->json(['message' => 'Unauthorized action.'], 403);
        }

        // Validar os dados introduzidos
        $request->validate([
            'name'     => 'required|string|max:255',
            'email'    => 'required|email|unique:clients',
            'password' => 'required|string|min:6',
        ]);

        // Store Client
        $client = Client::create($request->all());
        return response()->json($client, 201);
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $client = Client::find($id);
        if (!$client) {
            return response()->json(['message' => 'Client not found'], 404);
        }
        return response()->json($client);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        // Verifica se o token tem permissão para editar
        if (!$request->user()->tokenCan('edit')) {
            return response()->json(['message' => 'Unauthorized action.'], 403);
        }

        $client = Client::findOrFail($id);
        $request->validate([
            'name'     => 'required|string|max:255',
            'email'    => 'required|email|unique:clients,email,' . $id,
            'password' => 'required|string|min:6',
        ]);

        $client->update($request->all());
        return response()->json($client);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Request $request, string $id)
    {
        // Verifica se o token tem permissão para eliminar
        if (!$request->user()->tokenCan('delete')) {
            return response()->json(['message' => 'Unauthorized action.'], 403);
        }

        $client = Client::find($id);
        if (!$client) {
            return response()->json(['message' => 'Client not found'], 404);
        }

        $client->delete();
        return response()->json(['message' => 'Client deleted'], 200);
    }
}
