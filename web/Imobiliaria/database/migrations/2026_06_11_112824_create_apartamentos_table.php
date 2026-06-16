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
Schema::create('apartamentos', function (Blueprint $table) {
    $table->id();
    $table->string('referencia')->unique(); // Para podermos pesquisar facilmente
    $table->string('tipologia'); // T0, T1, T2, etc.
    $table->string('morada');
    $table->integer('area'); // Área em m²
    $table->decimal('preco', 12, 2); // Suporta valores altos e duas casas decimais
    $table->string('fotografia')->nullable(); // O caminho do ficheiro
    $table->enum('estado', ['Disponível', 'Vendido'])->default('Disponível');
    $table->timestamps();
});
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('apartamentos');
    }
};
