<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\ClienteController;
use App\Http\Controllers\ViaturaController;
use App\Http\Controllers\VendaController;

// Models para os KPIs
use App\Models\Cliente;
use App\Models\Viatura;
use App\Models\Venda;

// Página Inicial totalmente pública
Route::get('/', function () {

    // 1. Cálculos para as caixas de KPI
    $faturacaoTotal  = Venda::sum('valor_venda');
    $stockDisponivel = Viatura::where('estado', 'disponível')->count();
    $totalVendidos   = Viatura::where('estado', 'vendido')->count();
    $totalClientes   = Cliente::count();

    // 2. Procurar as últimas 5 transações
    $ultimasVendas = Venda::with(['cliente', 'viatura'])
        ->orderBy('id', 'desc')
        ->take(5)
        ->get();

    return view('welcome', compact(
        'faturacaoTotal',
        'stockDisponivel',
        'totalVendidos',
        'totalClientes',
        'ultimasVendas'
    ));
})->name('dashboard');

// Rotas CRUD também livres de autenticação
Route::resource('clientes', ClienteController::class);
Route::resource('viaturas', ViaturaController::class);
Route::resource('vendas', VendaController::class);

Route::view('/termos', 'termos')->name('termos');
Route::view('/privacidade', 'privacidade')->name('privacidade');
