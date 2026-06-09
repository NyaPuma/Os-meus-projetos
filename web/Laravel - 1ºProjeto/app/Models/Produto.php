<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Produto extends Model
{
    use HasFactory;

    // Define explicitamente o nome da tabela (seguindo o teu padrão)
    protected $table = 'produtos';

    // Atributos que podem ser preenchidos em massa (Mass Assignment)
    protected $fillable = [
        'nome',
        'referencia',
        'codigo_barras',
        'preco_custo',
        'preco_venda',
        'portes_envio', // Adicionado aqui para aceitar os dados dos formulários
        'taxa_iva',
        'stock_atual',
        'stock_minimo',
        'estado',
        'descricao',
    ];

    protected $hidden = [];

    // Conversão de tipos (Casting) utilizando a sintaxe do Laravel 11
    protected function casts(): array
    {
        return [
            'preco_custo'  => 'decimal:2',
            'preco_venda'  => 'decimal:2',
            'portes_envio' => 'decimal:2', // Adicionado aqui para garantir precisão monetária
            'taxa_iva'     => 'integer',
            'stock_atual'  => 'integer',
            'stock_minimo' => 'integer',
            'estado'       => 'string',
            'created_at'   => 'datetime',
            'updated_at'   => 'datetime',
        ];
    }

    // Scope para produtos com stock disponível (Disponíveis)
    public function scopeAtivos($query)
    {
        return $query->where('estado', 'ativo');
    }

    // Scope para produtos indisponíveis ou descontinuados
    public function scopeInativos($query)
    {
        return $query->where('estado', 'inativo');
    }

    // Scope útil para identificar rapidamente produtos com rutura ou stock crítico
    public function scopeStockCritico($query)
    {
        return $query->whereColumn('stock_atual', '<=', 'stock_minimo');
    }
}
