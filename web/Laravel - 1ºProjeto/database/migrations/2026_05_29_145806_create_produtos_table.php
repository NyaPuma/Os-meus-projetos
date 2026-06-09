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
        Schema::create('produtos', function (Blueprint $table) {
            $table->id();

            // Identificação do Produto
            $table->string('nome');
            $table->string('referencia')     ->unique(); // SKU único
            $table->string('codigo_barras')  ->unique()->nullable(); // EAN / UPC

            // Componente Financeira (Preços e Impostos)
            // 8 dígitos no total, 2 casas decimais (ex: 999999.99)
            $table->decimal('preco_custo', 8, 2)->nullable();
            $table->decimal('preco_venda', 8, 2);
            $table->decimal('portes_envio', 8, 2)->default(0.00); // Novo campo adicionado aqui
            $table->integer('taxa_iva')         ->default(23); // 23%, 13%, 6%, 0%

            // Gestão de Inventário e Stock
            $table->integer('stock_atual')      ->default(0);
            $table->integer('stock_minimo')     ->default(0); // Limiar para alertas

            // Estado do Produto no Sistema
            $table->enum('estado', ['ativo', 'inativo'])
                ->default('ativo');

            // Detalhes Adicionais
            $table->text('descricao')           ->nullable();

            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('produtos');
    }
};
