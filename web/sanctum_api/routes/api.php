<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\ClientController;
USE App\Http\Controllers\AuthController;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::get('/status', function () {
    return response()->json([
        'status' => 'API is running',
        'message' => 'Welcome to the API',
    ]);
});

Route::apiResource('/clients', ClientController::class) -> middleware('auth:sanctum');

Route::post  ('/register',     [AuthController::class, 'register']);
Route::post  ('/login',        [AuthController::class, 'login'   ]);
Route::post  ('/logout',       [AuthController::class, 'logout'  ]) -> middleware('auth:sanctum');
