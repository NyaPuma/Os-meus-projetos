<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Cliente;
use App\Models\Viatura;
use App\Models\Venda;
use Carbon\Carbon;

class DatabaseSeeder extends Seeder
{
    public function run()
    {
        // 1. Criar 100 Clientes usando a Factory
        $clientes = Cliente::factory()->count(100)->create();

        // 2. Criar 130 Viaturas (100 para vender e 30 para sobrarem como disponíveis)
        $viaturas = Viatura::factory()->count(130)->create();

        // 3. Selecionar uma amostra aleatória de 100 viaturas para simular que foram vendidas
        $viaturasVendidas = $viaturas->shuffle()->take(100);

        foreach ($viaturasVendidas as $viatura) {
            // Seleciona um cliente aleatório do ecossistema criado acima
            $clienteAleatorio = $clientes->random();

            // Gera uma data de contrato aleatória distribuída pelos últimos 12 meses
            $dataContrato = Carbon::now()->subDays(rand(1, 365));

            // Cria o registo de venda correspondente
            // Dentro do foreach ($viaturasVendidas as $viatura) do seu DatabaseSeeder:
            Venda::create([
                'cliente_id' => $clienteAleatorio->id,
                'viatura_id' => $viatura->id,
                'data_venda' => $dataContrato->format('Y-m-d'),
                'valor_venda' => $viatura->preco, // Usa o preço exato gerado para esta viatura!
                'observacoes' => rand(0, 1) ? 'Contrato fechado com revisão incluída e garantia total de 24 meses.' : null,
            ]);

            // Sincroniza o estado da viatura para 'vendido' respeitando a regra do negócio
            $viatura->update(['estado' => 'vendido']);
        }
    }
}
