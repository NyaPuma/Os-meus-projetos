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
    $table->id();
    // Relacionamento com Clientes (Um cliente pode ter várias vendas)
    $table->foreignId('cliente_id')->constrained('clientes')->onDelete('cascade');

    // Relacionamento ÚNICO com Apartamentos (Um apartamento só pode ter UMA venda)
    $table->foreignId('apartamento_id')->unique()->constrained('apartamentos')->onDelete('cascade');

    $table->date('data_venda');
    $table->decimal('valor_venda', 12, 2);
    $table->text('observacoes')->nullable();
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
