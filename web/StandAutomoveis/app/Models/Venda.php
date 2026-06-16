<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Relations\BelongsTo;
use Illuminate\Database\Eloquent\Factories\HasFactory;

class Venda extends Model
{
    use HasFactory;
    protected $fillable = ['cliente_id', 'viatura_id', 'data_venda', 'valor_venda', 'observacoes'];

    public function cliente(): BelongsTo
    {
        return $this->belongsTo(Cliente::class); // Uma venda pertence a um cliente
    }

    public function viatura(): BelongsTo
    {
        return $this->belongsTo(Viatura::class); // Uma venda pertence a uma viatura
    }
}
