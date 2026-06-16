<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\ApartamentoController;
use App\Http\Controllers\ClienteController;
use App\Http\Controllers\VendaController;
use App\Http\Controllers\AuthController;
use App\Http\Controllers\DashboardController;

/*
|--------------------------------------------------------------------------
| Rotas Públicas (Qualquer pessoa pode ver)
|--------------------------------------------------------------------------
*/
// 1. A Dashboard principal da aplicação
Route::get('/', [DashboardController::class, 'index'])->name('dashboard');

// 2. Ecrãs de Autenticação (Apenas para convidados/guests)
Route::middleware('guest')->group(function () {
    Route::get('/login', [AuthController::class, 'showLogin'])->name('login');
    Route::post('/login', [AuthController::class, 'login'])->name('login.post');
    Route::get('/register', [AuthController::class, 'showRegister'])->name('register');
    Route::post('/register', [AuthController::class, 'register'])->name('register.post');
});

Route::get('/documentacao', function () {
    return view('documentacao');
})->name('documentacao');

Route::get('/termos-de-servico', function () {
    return view('termos');
})->name('termos');

Route::get('/politica-de-privacidade', function () {
    return view('privacidade');
})->name('privacidade');

/*
|--------------------------------------------------------------------------
| Rotas Protegidas (Requer Login Obrigatório)
|--------------------------------------------------------------------------
*/
Route::middleware('auth')->group(function () {

    // Rota para fazer logout
    Route::post('/logout', [AuthController::class, 'logout'])->name('logout');

    // Todo o ecossistema interno fica enclausurado aqui:
    Route::resource('apartamentos', ApartamentoController::class);
    Route::resource('clientes', ClienteController::class);
    Route::resource('vendas', VendaController::class);
});
