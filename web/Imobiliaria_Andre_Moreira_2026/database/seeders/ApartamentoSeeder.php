<?php

namespace Database\Seeders;

use App\Models\Apartamento;
use Illuminate\Database\Eloquent\Factories\Factory;
use Illuminate\Database\Eloquent\Factories\Sequence;
use Illuminate\Database\Seeder;

class ApartamentoSeeder extends Seeder
{
    public function run(): void
    {
        // 1. Teus registos manuais originais
        Apartamento::create([
            'referencia' => 'APT-001',
            'tipologia' => 'T2',
            'morada' => 'Rua das Flores, Braga',
            'area' => 85,
            'preco' => 185000.00,
            'fotografia' => null,
            'estado' => 'Disponível'
        ]);

        Apartamento::create([
            'referencia' => 'APT-003',
            'tipologia' => 'T1',
            'morada' => 'Rua do Souto, Guimarães',
            'area' => 60,
            'preco' => 135000.00,
            'fotografia' => null,
            'estado' => 'Disponível'
        ]);

        // 2. Cria mais 98 apartamentos automáticos usando uma Sequence nativa do Laravel
        // O index começa em 0, por isso adicionamos 4 para o primeiro registo ser o APT-004
        Apartamento::factory()
            ->count(98)
            ->state(new Sequence(
                fn (Sequence $sequence) => [
                    'referencia' => 'APT-' . str_pad($sequence->index + 4, 3, '0', STR_PAD_LEFT)
                ],
            ))
            ->create();
    }
}
