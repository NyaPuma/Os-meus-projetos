<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Venda;

class VendaSeeder extends Seeder
{
    public function run(): void
    {
        Venda::create([
            'cliente_id' => 1,  // João Silva
            'viatura_id' => 3,  // Renault Clio (Vendido)
            'data_venda' => '2026-05-10',
            'valor_venda' => 12000.00, // Preço negociado
            'observacoes' => 'Venda realizada com garantia de 18 meses incluída.'
        ]);
    }
}
