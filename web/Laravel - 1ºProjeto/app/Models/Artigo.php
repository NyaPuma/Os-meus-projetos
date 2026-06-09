<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Artigo extends Model
{
    use HasFactory;

    protected $fillable = [
        'descricao',
        'caracteristicas',
        'preco',
        'foto',
        'categoria_id',
    ];

    public function categoria(){
        return $this->belongsTo(Categoria::class);
    }
}
