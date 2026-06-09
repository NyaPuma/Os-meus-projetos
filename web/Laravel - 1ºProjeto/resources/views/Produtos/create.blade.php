<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Novo Produto</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">
</head>

<body>

<div class="container mt-5">
    <div class="card shadow">

        <div class="card-header">
            <h3 class="mb-0">Inserir novo produto</h3>
        </div>

        <div class="card-body">
            <form action="{{ route('produtos.store') }}" method="POST">
                @csrf

                <div class="mb-3">
                    <label for="lb_nome" class="form-label">Nome do Produto</label>
                    <input type="text"
                           name="nome"
                           id="lb_nome"
                           class="form-control @error('nome') is-invalid @enderror"
                           value="{{ old('nome') }}">
                    @error('nome')
                        <div class="invalid-feedback">{{ $message }}</div>
                    @enderror
                </div>

                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="lb_referencia" class="form-label">Referência / SKU</label>
                        <input type="text"
                               name="referencia"
                               id="lb_referencia"
                               class="form-control @error('referencia') is-invalid @enderror"
                               value="{{ old('referencia') }}"
                               placeholder="Ex: PROD-001">
                        @error('referencia')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>

                    <div class="col-md-6 mb-3">
                        <label for="lb_codigo_barras" class="form-label">Código de Barras (EAN)</label>
                        <input type="text"
                               name="codigo_barras"
                               id="lb_codigo_barras"
                               class="form-control @error('codigo_barras') is-invalid @enderror"
                               value="{{ old('codigo_barras') }}">
                        @error('codigo_barras')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3 mb-3">
                        <label for="lb_preco_custo" class="form-label">Preço de Custo (€)</label>
                        <input type="number"
                               step="0.01"
                               name="preco_custo"
                               id="lb_preco_custo"
                               class="form-control"
                               value="{{ old('preco_custo', '0.00') }}">
                    </div>

                    <div class="col-md-3 mb-3">
                        <label for="lb_preco_venda" class="form-label">Preço de Venda (€)</label>
                        <input type="number"
                               step="0.01"
                               name="preco_venda"
                               id="lb_preco_venda"
                               class="form-control @error('preco_venda') is-invalid @enderror"
                               value="{{ old('preco_venda', '0.00') }}">
                        @error('preco_venda')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>

                    <div class="col-md-3 mb-3">
                        <label for="lb_portes_envio" class="form-label">Portes de Envio (€)</label>
                        <input type="number"
                               step="0.01"
                               name="portes_envio"
                               id="lb_portes_envio"
                               class="form-control @error('portes_envio') is-invalid @enderror"
                               value="{{ old('portes_envio', '0.00') }}">
                        @error('portes_envio')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>

                    <div class="col-md-3 mb-3">
                        <label for="lb_taxa_iva" class="form-label">Taxa de IVA</label>
                        <select name="taxa_iva" id="lb_taxa_iva" class="form-select">
                            <option value="23" {{ old('taxa_iva') == '23' ? 'selected' : '' }}>23% (Taxa Normal)</option>
                            <option value="13" {{ old('taxa_iva') == '13' ? 'selected' : '' }}>13% (Taxa Intermédia)</option>
                            <option value="6" {{ old('taxa_iva') == '6' ? 'selected' : '' }}>6% (Taxa Reduzida)</option>
                            <option value="0" {{ old('taxa_iva') == '0' ? 'selected' : '' }}>0% (Isento)</option>
                        </select>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 mb-3">
                        <label for="lb_stock_atual" class="form-label">Stock Atual</label>
                        <input type="number"
                               name="stock_atual"
                               id="lb_stock_atual"
                               class="form-control"
                               value="{{ old('stock_atual', '0') }}">
                    </div>

                    <div class="col-md-4 mb-3">
                        <label for="lb_stock_minimo" class="form-label">Stock Mínimo (Alerta)</label>
                        <input type="number"
                               name="stock_minimo"
                               id="lb_stock_minimo"
                               class="form-control"
                               value="{{ old('stock_minimo', '5') }}">
                    </div>

                    <div class="col-md-4 mb-3">
                        <label for="lb_estado" class="form-label">Estado de Venda</label>
                        <select name="estado" id="lb_estado" class="form-select">
                            <option value="ativo" {{ old('estado', 'ativo') == 'ativo' ? 'selected' : '' }}>Disponível</option>
                            <option value="inativo" {{ old('estado') == 'inativo' ? 'selected' : '' }}>Descontinuado / Indisponível</option>
                        </select>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="lb_descricao" class="form-label">Descrição do Produto</label>
                    <textarea name="descricao"
                              id="lb_descricao"
                              rows="4"
                              class="form-control"
                              placeholder="Breve descrição sobre as características do produto...">{{ old('descricao') }}</textarea>
                </div>

                <div class="d-flex gap-2">
                    <button type="submit" class="btn btn-success">
                        Guardar Produto
                    </button>
                    <a href="{{ route('produtos.index') }}" class="btn btn-secondary">
                        Voltar
                    </a>
                </div>
            </form>
        </div>
    </div>
</div>
</body>
</html>
