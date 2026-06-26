<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Client;

class ApiController extends Controller
{
    public function status()
    {
        return response() -> json([
            'status'  => 'ok',
            'message' => 'API is running',
        ]);
    }

    public function clients()
    {
        $clients = Client::paginate(10);
        return response() -> json([
            'status'  => 'ok',
            'message' => 'Clients retrieved successfully',
            'data'    => $clients,
        ],200);
    }

    public function clientsById($id)
    {
        $client = Client::find($id);
        return response() -> json([
            'status'  => 'ok',
            'message' => 'Client retrieved successfully',
            'data'    => $client,
        ],200);
    }

    public function clientsByIdHidden(Request $request)
    {
        // ver se o id é fornecido no pedido
        if (!$request -> id) {
            return response() -> json([
                'status'  => 'error',
                'message' => 'ID is required',
            ],400);
        }

        $client = Client::find($request -> id);
        return response() -> json([
            'status'  => 'ok',
            'message' => 'Client retrieved successfully',
            'data'    => $client,
        ],200);
    }

    public function addClient(Request $request)
    {
        // ver se o nome e email são fornecidos no pedido
        if (!$request -> name || !$request -> email) {
            return response() -> json([
                'status'  => 'error',
                'message' => 'Name and Email are required',
            ],400);
        }

        $client = Client::create([
            'name'  => $request -> name,
            'email' => $request -> email,
        ]);

        return response() -> json([
            'status'  => 'ok',
            'message' => 'Client added successfully',
            'data'    => $client,
        ],201);
    }

    public function updateClient(Request $request, $id)
    {
        // ver se o nome e email são fornecidos no pedido
        if (!$request -> name || !$request -> email) {
            return response() -> json([
                'status'  => 'error',
                'message' => 'Name and Email are required',
            ],400);
        }

        $client = Client::find($id);
        if (!$client) {
            return response() -> json([
                'status'  => 'error',
                'message' => 'Client not found',
            ],404);
        }

        $client -> name  = $request -> name;
        $client -> email = $request -> email;
        $client -> save();

        return response() -> json([
            'status'  => 'ok',
            'message' => 'Client updated successfully',
            'data'    => $client,
        ],200);
    }

    public function deleteClient($id)
    {
        $client = Client::find($id);
        if (!$client) {
            return response() -> json([
                'status'  => 'error',
                'message' => 'Client not found',
            ],404);
        }

        $client -> delete();

        return response() -> json([
            'status'  => 'ok',
            'message' => 'Client deleted successfully',
        ],200);
    }
}
