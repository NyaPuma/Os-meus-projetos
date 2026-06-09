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
        Schema::create('fornecedors', function (Blueprint $table) {
            $table->id();

            $table->string('nome');

            $table->string('nif')           ->unique()->nullable();

            $table->string('morada')        ->nullable();
            $table->string('codigo_postal') ->nullable();
            $table->string('localidade')    ->nullable();
            $table->string('pais')          ->default('Portugal');

            $table->string('email')         ->unique();
            $table->string('telefone')      ->nullable();
            $table->string('website')       ->nullable();

            $table->string('contacto')      ->nullable();

            $table->enum('estado', ['ativo', 'inativo'])
                ->default('ativo');

            $table->text('observacoes')     ->nullable();

            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('fornecedors');
    }
};
