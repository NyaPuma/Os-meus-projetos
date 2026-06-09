<?php

namespace Database\Factories;

use App\Models\Fornecedor;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends Factory<Fornecedor>
 */
class FornecedorFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        return [
            //
            'nome'          => fake()->company(),

            'nif'           => fake()->unique()->numerify('#########'),

            'contacto'      => fake()->name(),

            'email'         => fake()->unique()->safeEmail(),
            'telefone'      => fake()->phoneNumber(),
            'website'       => fake()->url(),

            'morada'        => fake()->streetAddress(),
            'codigo_postal' => fake()->postcode(),
            'localidade'    => fake()->city(),
            'pais'          => 'Portugal',

            'estado'        => fake()->randomElement(['ativo', 'inativo']),

            'observacoes'   => fake()->sentence(),
        ];
    }
}
