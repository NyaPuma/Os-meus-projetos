<?php

namespace App\Http\Controllers;

use App\Models\Apartamento;
use App\Models\Cliente;
use App\Models\Venda;
use Illuminate\Http\Request;

class DashboardController extends Controller
{
    /**
     * Exibir a Dashboard principal com o portefólio real.
     */
    public function index()
    {
        // 1. Total global de apartamentos
        $totalApartamentos = Apartamento::count();

        // 2. Apartamentos disponíveis para venda
        // Nota: Altera 'Disponível' ou 'estado' caso a tua coluna na base de dados use outro nome (ex: 'disponivel', 1)
        $apartamentosDisponiveis = Apartamento::where('estado', 'Disponível')->count();

        // 3. Total de clientes na agência
        $totalClientes = Cliente::count();

        // 4. Volume de Negócios (Soma de todas as escrituras realizadas)
        $faturacaoTotal = Venda::sum('valor_venda');

        // 5. Últimas 5 vendas celebradas (com relações carregadas para evitar problemas de performance N+1)
        $ultimasVendas = Venda::with(['apartamento', 'cliente'])
            ->latest('data_venda') // Ordena pelas mais recentes
            ->take(5)
            ->get();

        // Retorna a tua vista com todas as variáveis que ela precisa
        return view('dashboard', compact(
            'totalApartamentos',
            'apartamentosDisponiveis',
            'totalClientes',
            'faturacaoTotal',
            'ultimasVendas'
        ));
    }
}
