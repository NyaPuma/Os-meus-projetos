<?php

namespace Database\Factories;

use App\Models\Cliente;
use Illuminate\Database\Eloquent\Factories\Factory;

class ClienteFactory extends Factory
{
    protected $model = Cliente::class;

    public function definition(): array
    {
        // Define o Faker para gerar dados localizados em Português
        $fakerPt = \Faker\Factory::create('pt_PT');

        return [
            'nome' => $fakerPt->name(),
            'email' => $this->faker->unique()->safeEmail(),
            'telefone' => $fakerPt->phoneNumber(), // Gera telemóveis/telefones PT
            'morada' => $fakerPt->address(),
            'nif' => $this->faker->unique()->regexify('[1-2][0-9]{8}'), // Gera um NIF plausível de 9 dígitos
        ];
    }
}
