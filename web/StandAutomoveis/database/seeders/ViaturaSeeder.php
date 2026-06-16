<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Viatura;

class ViaturaSeeder extends Seeder
{
    public function run(): void
    {
        Viatura::create([
            'marca' => 'BMW',
            'modelo' => 'Series 3',
            'matricula' => 'AA-00-XX',
            'ano' => 2020,
            'quilometros' => 45000,
            'preco' => 29500.00,
            'foto' => null, // Trataremos do upload mais à frente
            'estado' => 'disponível'
        ]);

        Viatura::create([
            'marca' => 'Mercedes-Benz',
            'modelo' => 'Classe A',
            'matricula' => 'BB-11-YY',
            'ano' => 2021,
            'quilometros' => 28000,
            'preco' => 31000.00,
            'foto' => null,
            'estado' => 'disponível'
        ]);

        Viatura::create([
            'marca' => 'Renault',
            'modelo' => 'Clio',
            'matricula' => 'CC-22-ZZ',
            'ano' => 2018,
            'quilometros' => 85000,
            'preco' => 12500.00,
            'foto' => null,
            'estado' => 'vendido' // Esta viatura já vai constar como vendida!
        ]);
    }
}
