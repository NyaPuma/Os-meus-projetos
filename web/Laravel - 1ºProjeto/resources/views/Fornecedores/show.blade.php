<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Detalhes do Fornecedor</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css"
          rel="stylesheet">
</head>

<body>

<div class="container mt-5">
    <div class="card shadow">
        <div class="card-header">
            <h3>Detalhes do fornecedor</h3>
        </div>
        <div class="card-body">
            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>ID:</strong>
                    {{ $fornecedor->id }}
                </div>
                <div class="col-md-6">
                    <strong>Estado:</strong>
                    @if ($fornecedor->estado == 'ativo')
                        <span class="badge bg-success">
                            Ativo
                        </span>
                    @else
                        <span class="badge bg-danger">
                            Inativo
                        </span>
                    @endif
                </div>
            </div>
            <hr>
            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>Nome:</strong>
                    {{ $fornecedor->nome }}
                </div>
                <div class="col-md-6">
                    <strong>NIF:</strong>
                    {{ $fornecedor->nif }}
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>Pessoa de contacto:</strong>
                    {{ $fornecedor->contacto }}
                </div>
                <div class="col-md-6">
                    <strong>Telefone:</strong>
                    {{ $fornecedor->telefone }}
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>Email:</strong>
                    {{ $fornecedor->email }}
                </div>
                <div class="col-md-6">
                    <strong>Website:</strong>
                    @if ($fornecedor->website)
                        <a href="{{ $fornecedor->website }}"
                           target="_blank">
                            {{ $fornecedor->website }}
                        </a>
                    @endif
                </div>
            </div>
            <hr>
            <div class="mb-3">
                <strong>Morada:</strong>
                {{ $fornecedor->morada }}
            </div>
            <div class="row mb-3">
                <div class="col-md-4">
                    <strong>Código Postal:</strong>
                    {{ $fornecedor->codigo_postal }}
                </div>
                <div class="col-md-4">
                    <strong>Localidade:</strong>
                    {{ $fornecedor->localidade }}
                </div>
                <div class="col-md-4">
                    <strong>País:</strong>
                    {{ $fornecedor->pais }}
                </div>
            </div>
            <hr>
            <div class="mb-4">
                <strong>Observações:</strong>
                <div class="border rounded p-3 mt-2 bg-light">
                    {{ $fornecedor->observacoes ?? 'Sem observações.' }}
                </div>
            </div>
            <div class="d-flex gap-2">
                <a href="{{ route('fornecedores.index') }}"
                   class="btn btn-primary">
                    Voltar
                </a>
                <a href="{{ route('fornecedores.edit', $fornecedor->id) }}"
                   class="btn btn-warning">
                    Editar
                </a>
                <form action="{{ route('fornecedores.destroy', $fornecedor->id) }}"
                      method="POST">
                    @csrf
                    @method('DELETE')
                    <button type="submit"
                            class="btn btn-danger"
                            onclick="return confirm('Deseja eliminar este fornecedor?')">
                        Eliminar
                    </button>
                </form>
            </div>
        </div>
    </div>
</div>
</body>
</html>
