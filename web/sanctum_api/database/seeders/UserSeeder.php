<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use App\Models\User;

class UserSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
        $user =  new User();
        $user -> name     = 'utilizador_app';
        $user -> email    = 'utilizador_app@api.pt';
        $user -> password = bcrypt('123456789');
        $user -> save();
    }
}
