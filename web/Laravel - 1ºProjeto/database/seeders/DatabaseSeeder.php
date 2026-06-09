<?php

namespace Database\Seeders;

use App\Models\Cliente;
use App\Models\User;
use App\Models\Fornecedor;
use App\Models\Produto;
use App\Models\Categoria;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    use WithoutModelEvents;

    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        User::factory(10)->create();

        Cliente::factory(50) -> create();
        Fornecedor::factory(50) -> create();
        Produto::factory(50) -> create();

        Categoria::create([
            'categoria'=>'Informática',
        ]);
        Categoria::create([
            'categoria'=>'Telemóveis',
        ]);
        Categoria::create([
            'categoria'=>'Acessórios',
        ]);
        Categoria::create([
            'categoria'=>'Consumíveis',
        ]);

        // User::factory()->create([
        //     'name' => 'Test User',
        //     'email' => 'test@example.com',
        // ]);
    }
}
