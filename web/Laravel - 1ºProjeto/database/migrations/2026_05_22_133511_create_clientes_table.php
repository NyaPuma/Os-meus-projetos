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
        Schema::create('clientes', function (Blueprint $table) {
            $table->id();
            $table->string("nome");

            // NOVO: NIF (Único e opcional, caso queiras registar clientes sem NIF de início)
            $table->string("nif", 9)->nullable()->unique();

            $table->string("morada")->nullable();
            $table->string("localidade")->nullable();

            // NOVO: País (Padrão 'PT' para Portugal)
            $table->string("pais", 3)->default("PT");

            $table->string("email")->unique();
            $table->string("telefone")->nullable();

            // NOVO: Estado (Padrão 'ativo')
            $table->enum("estado", ["ativo", "inativo"])->default("ativo");

            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('clientes');
    }
};
