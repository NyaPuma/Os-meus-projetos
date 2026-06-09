<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Novo Cliente</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css"
          rel="stylesheet">
</head>

<body>

<div class="container mt-5">
    <div class="card shadow">

        <div class="card-header">
            <h3 class="mb-0">Inserir novo cliente</h3>
        </div>

        <div class="card-body">
            <form action="{{ route('clientes.store') }}" method="POST">
                @csrf

                <div class="row">
                    <div class="col-md-8 mb-3">
                        <label for="lb_nome" class="form-label">Nome</label>
                        <input type="text"
                               name="nome"
                               id="lb_nome"
                               class="form-control @error('nome') is-invalid @enderror"
                               value="{{ old('nome') }}">
                        @error('nome')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>

                    <div class="col-md-4 mb-3">
                        <label for="lb_nif" class="form-label">NIF</label>
                        <input type="text"
                               name="nif"
                               id="lb_nif"
                               class="form-control @error('nif') is-invalid @enderror"
                               value="{{ old('nif') }}"
                               placeholder="9 dígitos">
                        @error('nif')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="lb_morada" class="form-label">Morada</label>
                        <input type="text"
                               name="morada"
                               id="lb_morada"
                               class="form-control"
                               value="{{ old('morada') }}">
                    </div>

                    <div class="col-md-3 mb-3">
                        <label for="lb_localidade" class="form-label">Localidade</label>
                        <input type="text"
                               name="localidade"
                               id="lb_localidade"
                               class="form-control"
                               value="{{ old('localidade') }}">
                    </div>

                    <div class="col-md-3 mb-3">
                        <label for="lb_pais" class="form-label">País</label>
                        <select name="pais" id="lb_pais" class="form-select @error('pais') is-invalid @enderror">
                            <option value="PT" {{ old('pais', 'PT') == 'PT' ? 'selected' : '' }}>Portugal</option>
                            <option value="OUT" {{ old('pais') == 'OUT' ? 'selected' : '' }}>Estrangeiro / Outro</option>
                        </select>
                        @error('pais')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-5 mb-3">
                        <label for="lb_email" class="form-label">Email</label>
                        <input type="email"
                               name="email"
                               id="lb_email"
                               class="form-control @error('email') is-invalid @enderror"
                               value="{{ old('email') }}">
                        @error('email')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>

                    <div class="col-md-4 mb-3">
                        <label for="lb_telefone" class="form-label">Telefone</label>
                        <input type="text"
                               name="telefone"
                               id="lb_telefone"
                               class="form-control"
                               value="{{ old('telefone') }}">
                    </div>

                    <div class="col-md-3 mb-3">
                        <label for="lb_estado" class="form-label">Estado</label>
                        <select name="estado" id="lb_estado" class="form-select @error('estado') is-invalid @enderror">
                            <option value="ativo" {{ old('estado', 'ativo') == 'ativo' ? 'selected' : '' }}>Ativo</option>
                            <option value="inativo" {{ old('estado') == 'inativo' ? 'selected' : '' }}>Inativo</option>
                        </select>
                        @error('estado')
                            <div class="invalid-feedback">{{ $message }}</div>
                        @enderror
                    </div>
                </div>

                <hr class="mb-4">

                <div class="d-flex gap-2">
                    <button type="submit" class="btn btn-success">
                        Guardar
                    </button>
                    <a href="{{ route('clientes.index') }}" class="btn btn-secondary">
                        Voltar
                    </a>
                </div>
            </form>
        </div>
    </div>
</div>
</body>
</html>
