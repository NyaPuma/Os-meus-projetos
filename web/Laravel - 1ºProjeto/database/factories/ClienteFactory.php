<?php

namespace Database\Factories;

use App\Models\Cliente;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends Factory<Cliente>
 */
class ClienteFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [
            "nome"       => fake()->name(),

            // NOVO: NIF falso com 9 dígitos (geralmente começados por 1, 2, 5 ou 9 em Portugal)
            "nif"        => fake()->unique()->regexify('[1259][0-9]{8}'),

            "morada"     => fake()->address(),
            "localidade" => fake()->city(),

            // NOVO: Escolha aleatória com base nas tuas opções (ex: 80% Portugal, 20% Outro)
            "pais"       => fake()->randomElement(['PT', 'PT', 'PT', 'PT', 'OUT']),

            "telefone"   => fake()->phoneNumber(),
            "email"      => fake()->unique()->safeEmail(),

            // NOVO: Estado aleatório (ex: maior probabilidade de vir ativo)
            "estado"     => fake()->randomElement(['ativo', 'ativo', 'ativo', 'inativo'])
        ];
    }
}
