<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\HasOne;
use Illuminate\Database\Eloquent\Factories\HasFactory;

class Viatura extends Model
{
    use HasFactory;
    protected $fillable = ['marca', 'modelo', 'matricula', 'ano', 'quilometros', 'preco', 'foto', 'estado'];

    public function venda(): HasOne
    {
        return $this->hasOne(Venda::class); // Uma viatura pode estar associada a apenas uma venda
    }
}
