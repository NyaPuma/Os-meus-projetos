<?php

namespace Database\Factories;

use App\Models\Viatura;
use Illuminate\Database\Eloquent\Factories\Factory;

class ViaturaFactory extends Factory
{
    protected $model = Viatura::class;

    public function definition()
    {
        // Pool de carros para simular dados credíveis na tabela
        $carros = [
            'BMW' => ['116d', '320d', '520d', 'X3', 'i4'],
            'Mercedes-Benz' => ['Classe A', 'Classe C', 'Classe E', 'GLC', 'EQA'],
            'Audi' => ['A3 Sportback', 'A4 Avant', 'A6', 'Q3', 'e-tron'],
            'Volkswagen' => ['Golf', 'Polo', 'Passat', 'T-Roc', 'ID.4'],
            'Renault' => ['Clio', 'Megane', 'Captur', 'Zoe', 'Austral'],
            'Peugeot' => ['208', '308', '2008', '3008', '5008'],
            'Toyota' => ['Yaris', 'Corolla', 'C-HR', 'RAV4'],
        ];

        $marca = $this->faker->randomElement(array_keys($carros));
        $modelo = $this->faker->randomElement($carros[$marca]);

        return [
            'marca' => $marca,
            'modelo' => $modelo,
            'ano' => $this->faker->numberBetween(2015, 2026),
            'matricula' => $this->faker->unique()->regexify('[A-Z]{2}-[0-9]{2}-[A-Z]{2}'),
            'quilometros' => $this->faker->numberBetween(5000, 220000), // <-- ADICIONAR ESTA LINHA
            'preco' => $this->faker->numberBetween(11000, 65000),        // <-- ADICIONAR ESTA LINHA
            'foto' => null, // Fica nulo por omissão (pode usar uma imagem placeholder se preferir)
            'estado' => 'disponível',
        ];
    }
}
