<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Apartamento extends Model
{
    use HasFactory;

    /**
     * Atributos permitidos para mass assignment
     */
    protected $fillable = [
        'referencia',
        'tipologia',
        'morada',
        'area',
        'preco',
        'fotografia',
        'estado',
    ];

    /**
     * Boot do model
     * Gera automaticamente a referência interna
     */
    protected static function boot()
    {
        parent::boot();

        static::creating(function ($apartamento) {

            // Gera o próximo ID de forma simples
            $last = self::orderByDesc('id')->first();
            $next = $last ? $last->id + 1 : 1;

            $apartamento->referencia =
                'APT-' . str_pad($next, 4, '0', STR_PAD_LEFT);
        });
    }

    /**
     * Relação: Um Apartamento pode ter uma Venda associada.
     */
    public function venda()
    {
        return $this->hasOne(Venda::class);
    }
}
