<?php

use App\Http\Controllers\AboutController;
use App\Http\Controllers\ArtigoController;
use App\Http\Controllers\ClienteController;
use App\Http\Controllers\FornecedorController;
use App\Http\Controllers\ProdutoController; // <- Adicionado aqui
use App\Http\Controllers\ProfileController;
use App\Http\Controllers\MainController;
use App\Http\Controllers\StoreController;
use App\Http\Controllers\MeuControllerController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('welcome');
});

Route::get('/my_layout', [MeuControllerController::class,'index'])->name('my_layout');

Route::get('/about', [AboutController::class, 'index']);
Route::get('/main',  [MainController::class, 'index']);
Route::get('/store', [StoreController::class, 'index']);

// Clientes
Route::get('/clientes',               [ClienteController::class, 'index'])      ->name('clientes.index');
Route::post('/clientes',              [ClienteController::class, 'store'])      ->name('clientes.store');
Route::get('/clientes/create',        [ClienteController::class, 'create'])     ->name('clientes.create');
Route::get('/clientes/{id}',          [ClienteController::class, 'show'])       ->name('clientes.show');
Route::get('/editarCliente/{id}',     [ClienteController::class, 'edit'])       ->name('clientes.edit');
Route::put('/gravar/{id}',            [ClienteController::class, 'update'])     ->name('clientes.update');
Route::delete('/eliminar/{id}',       [ClienteController::class, 'destroy'])    ->name('clientes.destroy');

// Fornecedores
Route::get('/fornecedores',           [FornecedorController::class, 'index'])   ->name('fornecedores.index');
Route::post('/fornecedores',          [FornecedorController::class, 'store'])   ->name('fornecedores.store');
Route::get('/fornecedores/create',    [FornecedorController::class, 'create'])  ->name('fornecedores.create');
Route::get('/fornecedores/{id}',      [FornecedorController::class, 'show'])    ->name('fornecedores.show');
Route::get('/fornecedores/{id}/edit', [FornecedorController::class, 'edit'])    ->name('fornecedores.edit');
Route::put('/fornecedores/{id}',      [FornecedorController::class, 'update'])  ->name('fornecedores.update');
Route::delete('/fornecedores/{id}',   [FornecedorController::class, 'destroy']) ->name('fornecedores.destroy');

// Produtos
Route::get('/produtos',               [ProdutoController::class, 'index'])      ->name('produtos.index');
Route::post('/produtos',              [ProdutoController::class, 'store'])      ->name('produtos.store');
Route::get('/produtos/create',        [ProdutoController::class, 'create'])     ->name('produtos.create');
Route::get('/produtos/{id}',          [ProdutoController::class, 'show'])       ->name('produtos.show');
Route::get('/produtos/{id}/edit',     [ProdutoController::class, 'edit'])       ->name('produtos.edit');
Route::put('/produtos/{id}',          [ProdutoController::class, 'update'])     ->name('produtos.update');
Route::delete('/produtos/{id}',       [ProdutoController::class, 'destroy'])    ->name('produtos.destroy');

// Artigos
Route::get('/artigos',                [ArtigoController::class, 'index'])       ->name('artigos.index');
Route::post('/artigos',               [ArtigoController::class, 'store'])       ->name('artigos.store');
Route::get('/artigos/create',         [ArtigoController::class, 'create'])      ->name('artigos.create');
Route::get('/artigos/{id}',           [ArtigoController::class, 'show'])        ->name('artigos.show');
Route::get('/artigos/{id}/edit',      [ArtigoController::class, 'edit'])        ->name('artigos.edit');
Route::put('/artigos/{id}',           [ArtigoController::class, 'update'])      ->name('artigos.update');
Route::delete('/artigos/{id}',        [ArtigoController::class, 'destroy'])     ->name('artigos.destroy');

Route::get('/dashboard', function () {
    return view('dashboard');
})->middleware(['auth', 'verified'])->name('dashboard');

Route::middleware('auth')->group(function () {
    Route::get('/profile',    [ProfileController::class, 'edit'])   ->name('profile.edit');
    Route::patch('/profile',  [ProfileController::class, 'update']) ->name('profile.update');
    Route::delete('/profile', [ProfileController::class, 'destroy'])->name('profile.destroy');
});

require __DIR__.'/auth.php';
