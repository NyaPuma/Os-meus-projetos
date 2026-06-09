<?php

namespace Database\Factories;

use App\Models\Produto;
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * @extends Factory<Produto>
 */
class ProdutoFactory extends Factory
{
    /**
     * Define the model's default state.
     *
     * @return array<string, mixed>
     */
    public function definition(): array
    {
        // Geramos o preço de custo primeiro para garantir que a venda gera lucro coerente
        $precoCusto = fake()->randomFloat(2, 5, 150); // Preço entre 5.00€ e 150.00€
        $precoVenda = $precoCusto * fake()->randomFloat(2, 1.2, 1.8); // Margem de 20% a 80%

        return [
            // Agora dizemos ao Faker para gerar uma frase/nome único
            'nome'          => fake()->unique()->sentence(2),

            // Referência (SKU) no formato: PRD-XXXXX (único)
            'referencia'    => 'PRD-' . fake()->unique()->numerify('#####'),

            // Código de barras europeu padrão (EAN-13)
            'codigo_barras' => fake()->unique()->numerify('#############'),

            // Valores monetários coerentes
            'preco_custo'   => $precoCusto,
            'preco_venda'   => round($precoVenda, 2),

            // Portes de envio fictícios (60% de probabilidade de ser Grátis, 40% de ter custo tarifado)
            'portes_envio'  => fake()->randomElement([0.00, 0.00, 0.00, 3.99, 4.99, fake()->randomFloat(2, 5, 15)]),

            // Distribuição estatística das taxas de IVA em Portugal
            'taxa_iva'      => fake()->randomElement([23, 23, 23, 13, 6, 0]),

            // Gestão de stock e limites mínimos para disparo de alertas
            'stock_atual'   => fake()->numberBetween(0, 100),
            'stock_minimo'  => fake()->randomElement([5, 10, 15]),

            // Estado de disponibilidade no catálogo
            'estado'        => fake()->randomElement(['ativo', 'ativo', 'ativo', 'inativo']),

            // Descrição breve sobre as especificações do artigo
            'descricao'     => fake()->paragraph(2),
        ];
    }
}
