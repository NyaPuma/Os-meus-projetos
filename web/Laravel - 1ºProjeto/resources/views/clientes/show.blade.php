<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Detalhes do Cliente</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css"
          rel="stylesheet"
          integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB"
          crossorigin="anonymous">

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"
            integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI"
            crossorigin="anonymous">
    </script>
</head>

<body>

<div class="container mt-5">
    <div class="card shadow">

        <div class="card-header d-flex justify-content-between align-items-center">
            <h3 class="mb-0">Detalhes do cliente</h3>
            @if(($cliente->estado ?? 'ativo') == 'ativo')
                <span class="badge bg-success fs-6">Ativo</span>
            @else
                <span class="badge bg-danger fs-6">Inativo</span>
            @endif
        </div>

        <div class="card-body">
            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>ID:</strong>
                    {{ $cliente->id }}
                </div>
                <div class="col-md-6">
                    <strong>NIF:</strong>
                    {{ $cliente->nif ?? '---' }}
                </div>
            </div>

            <hr>

            <div class="row mb-3">
                <div class="col-md-12">
                    <strong>Nome:</strong>
                    {{ $cliente->nome }}
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>Morada:</strong>
                    {{ $cliente->morada }}
                </div>
                <div class="col-md-3">
                    <strong>Localidade:</strong>
                    {{ $cliente->localidade }}
                </div>
                <div class="col-md-3">
                    <strong>País:</strong>
                    {{ $cliente->pais ?? 'PT' }}
                </div>
            </div>

            <div class="row mb-3">
                <div class="col-md-6">
                    <strong>Email:</strong>
                    {{ $cliente->email }}
                </div>
                <div class="col-md-6">
                    <strong>Telefone:</strong>
                    {{ $cliente->telefone }}
                </div>
            </div>

            <hr class="mb-4">

            <div class="d-flex gap-2">
                <a href="{{ route('clientes.index') }}"
                   class="btn btn-primary">
                     Voltar
                </a>
                <a href="{{ route('clientes.edit', $cliente->id) }}"
                   class="btn btn-warning">
                     Editar
                </a>
                <form action="{{ route('clientes.destroy', $cliente->id) }}"
                      method="POST">
                    @csrf
                    @method('DELETE')
                    <button type="submit"
                            class="btn btn-danger"
                            onclick="return confirm('Deseja eliminar este registo?')">
                        Eliminar
                    </button>
                </form>
            </div>
        </div>
    </div>
</div>

</body>
</html>
