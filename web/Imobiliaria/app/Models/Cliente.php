<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Cliente extends Model
{
    use HasFactory;

    /**
     * Os atributos que podem ser atribuídos em massa (Mass Assignable).
     */
    protected $fillable = [
        'nome',
        'email',
        'telefone',
        'morada',
        'nif',
    ];

    /**
     * Relação: Um cliente pode realizar várias vendas.
     */
    public function vendas()
    {
        return $this->hasMany(Venda::class);
    }
}
