<?php

namespace Database\Factories;

use App\Models\Apartamento;
use Illuminate\Database\Eloquent\Factories\Factory;

class ApartamentoFactory extends Factory
{
    protected $model = Apartamento::class;

    public function definition(): array
    {
        $fakerPt = \Faker\Factory::create('pt_PT');

        return [
            // Deixamos a referência para ser preenchida dinamicamente no Seeder
            'referencia' => 'TEMP',
            'tipologia' => $this->faker->randomElement(['T1', 'T2', 'T3', 'T4', 'T2 Duplex']),
            'morada' => $fakerPt->streetAddress() . ', ' . $fakerPt->city(),
            'area' => $this->faker->numberBetween(50, 220),
            'preco' => $this->faker->randomFloat(2, 90000, 450000),
            'fotografia' => null,
            'estado' => $this->faker->randomElement(['Disponível', 'Vendido']),
        ];
    }
}
