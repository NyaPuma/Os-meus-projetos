<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Fornecedor extends Model
{
    use HasFactory;

    protected $table = 'fornecedors';

    protected $fillable = [
        'nome',
        'nif',
        'morada',
        'codigo_postal',
        'localidade',
        'pais',
        'email',
        'telefone',
        'website',
        'contacto',
        'estado',
        'observacoes',
    ];

    protected $hidden = [];

    protected function casts(): array
    {
        return [
            'estado' => 'string',
            'created_at' => 'datetime',
            'updated_at' => 'datetime',
        ];
    }

    // Scope para fornecedores ativos
    public function scopeAtivos($query)
    {
        return $query->where('estado', 'ativo');
    }

    // Scope para fornecedores inativos
    public function scopeInativos($query)
    {
        return $query->where('estado', 'inativo');
    }
}
