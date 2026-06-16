<?php

namespace Database\Factories;

use App\Models\Cliente;
use Illuminate\Database\Eloquent\Factories\Factory;

class ClienteFactory extends Factory
{
    protected $model = Cliente::class;

    public function definition()
    {
        return [
            'nome' => $this->faker->name(),
            'email' => $this->faker->unique()->safeEmail(),
            'telefone' => $this->faker->phoneNumber(), // Gera um número de telefone
            'morada' => $this->faker->address(),
            // Gera um NIF fictício único com 9 dígitos (começado por 1, 2, 5, etc.)
            'nif' => $this->faker->unique()->regexify('[12579][0-9]{8}'),
        ];
    }
}
