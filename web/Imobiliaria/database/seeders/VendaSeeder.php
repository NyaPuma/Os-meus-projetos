<?php

namespace Database\Seeders;

use App\Models\Venda;
use App\Models\Cliente;
use App\Models\Apartamento;
use Illuminate\Database\Seeder;

class VendaSeeder extends Seeder
{
    public function run(): void
    {
        // 1. Forçar a criação da tua venda manual específica de teste (APT-002 vendido ao João)
        // Criamos o apartamento APT-002 aqui diretamente para garantir que o ID bate certo com a venda
        $aptFixo = Apartamento::create([
            'referencia' => 'APT-002',
            'tipologia' => 'T3',
            'morada' => 'Avenida Central, Braga',
            'area' => 120,
            'preco' => 260000.00,
            'fotografia' => null,
            'estado' => 'Vendido'
        ]);

        Venda::create([
            'cliente_id' => 1,       // João Silva
            'apartamento_id' => $aptFixo->id,
            'data_venda' => '2026-05-15',
            'valor_venda' => 255000.00,
            'observacoes' => 'Venda concluída com sucesso com recurso a crédito habitação.'
        ]);

        // 2. Criar mais 99 vendas automáticas cruzando Clientes e Apartamentos aleatórios
        $clientesIds = Cliente::pluck('id')->toArray();

        // Vamos buscar apartamentos cujo estado seja 'Vendido' ou mudá-los para vendido ao associar à venda
        $apartamentos = Apartamento::where('id', '!=', $aptFixo->id)->get();

        foreach ($apartamentos->take(99) as $apartamento) {
            // Garante que o apartamento simulado na venda fica marcado como Vendido na BD
            $apartamento->update(['estado' => 'Vendido']);

            Venda::create([
                'cliente_id' => collect($clientesIds)->random(),
                'apartamento_id' => $apartamento->id,
                'data_venda' => fake()->dateTimeBetween('-1 year', 'now')->format('Y-m-d'),
                'valor_venda' => $apartamento->preco * fake()->randomElement([0.95, 0.98, 1.0]), // Desconto simulado de 0% a 5%
                'observacoes' => 'Contrato gerado automaticamente via Seeder do sistema.'
            ]);
        }
    }
}
