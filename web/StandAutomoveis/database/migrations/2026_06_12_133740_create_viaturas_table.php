<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('viaturas', function (Blueprint $table) {
            $table->id(); // ID
            $table->string('marca'); // Marca
            $table->string('modelo'); // Modelo
            $table->string('matricula')->unique(); // Matrícula
            $table->integer('ano'); // Ano
            $table->integer('quilometros'); // Quilómetros
            $table->decimal('preco', 10, 2); // Preço
            $table->string('foto')->nullable(); // Foto (pode ser nula inicialmente)
            $table->string('estado')->default('disponível'); // Estado (ex: disponível, vendido)
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('viaturas');
    }
};
