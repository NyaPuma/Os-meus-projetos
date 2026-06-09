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
        Schema::create('artigos', function (Blueprint $table) {
            $table->id();

            $table->string ('descricao');
            $table->string ('caracteristicas')->nullable();
            $table->decimal('preco',8,2)      ->nullable();
            $table->string ('foto')           ->nullable();

            // Criar Relação com a tabela categorias
            $table->foreignId   ('categoria_id')
                  ->constrained ('categorias')
                  ->onUpdate    ('cascade')
                  ->onDelete    ('cascade');

            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('artigos');
    }
};
