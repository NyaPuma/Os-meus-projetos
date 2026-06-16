<?php

namespace Database\Seeders;

use App\Models\Cliente;
use Illuminate\Database\Seeder;

class ClienteSeeder extends Seeder
{
    public function run(): void
    {
        // Cria os teus 2 registos manuais importantes para testes
        Cliente::create([
            'nome' => 'João Silva',
            'email' => 'joao.silva@email.com',
            'telefone' => '912345678',
            'morada' => 'Rua de Santa Catarina, Porto',
            'nif' => '251234567'
        ]);

        Cliente::create([
            'nome' => 'Maria Santos',
            'email' => 'maria.santos@email.com',
            'telefone' => '934567890',
            'morada' => 'Avenida da Liberdade, Lisboa',
            'nif' => '254567890'
        ]);

        // Cria mais 98 registos automáticos aleatórios para perfazer os 100
        Cliente::factory()->count(98)->create();
    }
}
