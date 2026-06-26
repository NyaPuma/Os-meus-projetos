<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\ApiController;

Route::get('/status',             [ApiController::class, 'status']);
Route::get('/clients',            [ApiController::class, 'clients']);

//Rota com o id no endereço
Route::get('/clientsById/{id}',   [ApiController::class, 'clientsById']);

//Rota sem o id no endereço
Route::post('/clientsByIdHidden', [ApiController::class, 'clientsByIdHidden']);

// Adicionar cliente
Route::post('/addClient',         [ApiController::class, 'addClient']);

// Alterar cliente
Route::put('/clients/{id}',       [ApiController::class, 'updateClient']);

// Eliminar cliente
Route::delete('/clients/{id}',    [ApiController::class, 'deleteClient']);
