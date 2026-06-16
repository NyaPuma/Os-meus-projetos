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
        Schema::create('vendas', function (Blueprint $table) {
            $table->id(); // ID

            // Chaves Estrangeiras e Relacionamentos
            $table->foreignId('cliente_id')->constrained('clientes')->onDelete('cascade');
            $table->foreignId('viatura_id')->unique()->constrained('viaturas')->onDelete('cascade');

            $table->date('data_venda'); // Data da Venda
            $table->decimal('valor_venda', 10, 2); // Valor da Venda
            $table->text('observacoes')->nullable(); // Observações
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('vendas');
    }
};
