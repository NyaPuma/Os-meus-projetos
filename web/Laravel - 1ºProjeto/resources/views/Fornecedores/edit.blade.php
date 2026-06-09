<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Editar Fornecedor</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css"
          rel="stylesheet">
</head>

<body>

<div class="container mt-5">
    <div class="card shadow">
        <div class="card-header">
            <h3>Editar fornecedor</h3>
        </div>
        <div class="card-body">
            <form action="{{ route('fornecedores.update', $fornecedor->id) }}"
                  method="POST">
                @csrf
                @method('PUT')
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="lb_nome" class="form-label">
                            Nome
                        </label>
                        <input type="text"
                               name="nome"
                               id="lb_nome"
                               class="form-control @error('nome') is-invalid @enderror"
                               value="{{ old('nome', $fornecedor->nome) }}">
                        @error('nome')
                            <div class="invalid-feedback">
                                {{ $message }}
                            </div>
                        @enderror
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="lb_nif" class="form-label">
                            NIF
                        </label>
                        <input type="text"
                               name="nif"
                               id="lb_nif"
                               class="form-control"
                               value="{{ old('nif', $fornecedor->nif) }}">
                    </div>
                </div>
                <div class="mb-3">
                    <label for="lb_contacto" class="form-label">
                        Pessoa de contacto
                    </label>
                    <input type="text"
                           name="contacto"
                           id="lb_contacto"
                           class="form-control"
                           value="{{ old('contacto', $fornecedor->contacto) }}">
                </div>
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="lb_email" class="form-label">
                            Email
                        </label>
                        <input type="email"
                               name="email"
                               id="lb_email"
                               class="form-control @error('email') is-invalid @enderror"
                               value="{{ old('email', $fornecedor->email) }}">
                        @error('email')
                            <div class="invalid-feedback">
                                {{ $message }}
                            </div>
                        @enderror
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="lb_telefone" class="form-label">
                            Telefone
                        </label>
                        <input type="text"
                               name="telefone"
                               id="lb_telefone"
                               class="form-control"
                               value="{{ old('telefone', $fornecedor->telefone) }}">
                    </div>
                </div>
                <div class="mb-3">
                    <label for="lb_website" class="form-label">
                        Website
                    </label>
                    <input type="text"
                           name="website"
                           id="lb_website"
                           class="form-control"
                           value="{{ old('website', $fornecedor->website) }}">
                </div>
                <div class="mb-3">
                    <label for="lb_morada" class="form-label">
                        Morada
                    </label>
                    <input type="text"
                           name="morada"
                           id="lb_morada"
                           class="form-control"
                           value="{{ old('morada', $fornecedor->morada) }}">
                </div>
                <div class="row">
                    <div class="col-md-4 mb-3">
                        <label for="lb_codigo_postal" class="form-label">
                            Código Postal
                        </label>
                        <input type="text"
                               name="codigo_postal"
                               id="lb_codigo_postal"
                               class="form-control"
                               value="{{ old('codigo_postal', $fornecedor->codigo_postal) }}">
                    </div>
                    <div class="col-md-4 mb-3">
                        <label for="lb_localidade" class="form-label">
                            Localidade
                        </label>
                        <input type="text"
                               name="localidade"
                               id="lb_localidade"
                               class="form-control"
                               value="{{ old('localidade', $fornecedor->localidade) }}">
                    </div>
                    <div class="col-md-4 mb-3">
                        <label for="lb_pais" class="form-label">
                            País
                        </label>
                        <input type="text"
                               name="pais"
                               id="lb_pais"
                               class="form-control"
                               value="{{ old('pais', $fornecedor->pais) }}">
                    </div>
                </div>
                <div class="mb-3">
                    <label for="lb_estado" class="form-label">
                        Estado
                    </label>
                    <select name="estado"
                            id="lb_estado"
                            class="form-select">
                        <option value="ativo"
                            {{ old('estado', $fornecedor->estado) == 'ativo' ? 'selected' : '' }}>
                            Ativo
                        </option>
                        <option value="inativo"
                            {{ old('estado', $fornecedor->estado) == 'inativo' ? 'selected' : '' }}>
                            Inativo
                        </option>
                    </select>
                </div>
                <div class="mb-3">
                    <label for="lb_observacoes" class="form-label">
                        Observações
                    </label>
                    <textarea name="observacoes"
                              id="lb_observacoes"
                              rows="4"
                              class="form-control">{{ old('observacoes', $fornecedor->observacoes) }}</textarea>
                </div>
                <div class="d-flex gap-2">
                    <button type="submit"
                            class="btn btn-success">
                        Guardar Alteração
                    </button>
                    <a href="{{ route('fornecedores.index') }}"
                       class="btn btn-secondary">
                        Voltar
                    </a>
                </div>
            </form>
        </div>
    </div>
</div>
</body>
</html>
