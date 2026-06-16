<?php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Cliente;

class ClienteSeeder extends Seeder
{
    public function run(): void
    {
        Cliente::create([
            'nome' => 'João Silva',
            'email' => 'joao.silva@email.com',
            'telefone' => '912345678',
            'morada' => 'Rua Augusta, nº 10, Lisboa',
            'nif' => '123456789'
        ]);

        Cliente::create([
            'nome' => 'Maria Santos',
            'email' => 'maria.santos@email.com',
            'telefone' => '934567890',
            'morada' => 'Avenida da Boavista, nº 500, Porto',
            'nif' => '987654321'
        ]);

        Cliente::create([
            'nome' => 'Carlos Sousa',
            'email' => 'carlos.sousa@email.com',
            'telefone' => '965432109',
            'morada' => 'Praça da República, nº 12, Braga',
            'nif' => '254136987'
        ]);
    }
}
