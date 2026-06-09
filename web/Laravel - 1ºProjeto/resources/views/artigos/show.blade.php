<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Detalhes do Artigo</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">
</head>

<body>

<div class="container mt-5">

    {{-- HEADER --}}
    <div class="d-flex justify-content-between align-items-center mb-4">
        <div class="d-flex align-items-center gap-3">
            <a href="{{ route('artigos.index') }}" class="btn btn-outline-secondary btn-sm">
                ← Voltar
            </a>
            <h1 class="mb-0">Detalhes do artigo</h1>
        </div>
    </div>

    {{-- CARD --}}
    <div class="card shadow">
        <div class="card-body">

            <div class="row">

                {{-- IMAGEM --}}
                <div class="col-md-4 text-center">
                    @if($artigo->foto)
                        <img src="{{ asset('storage/' . $artigo->foto) }}"
                             class="img-fluid rounded shadow-sm"
                             style="max-height: 250px; object-fit: cover;">
                    @else
                        <div class="text-muted">Sem imagem</div>
                    @endif
                </div>

                {{-- INFO --}}
                <div class="col-md-8">

                    <h3 class="mb-3">
                        {{ $artigo->descricao }}
                    </h3>

                    <p>
                        <strong>Características:</strong><br>
                        {{ $artigo->caracteristicas ?? 'Sem características' }}
                    </p>

                    <p>
                        <strong>Preço:</strong>
                        {{ number_format($artigo->preco, 2, ',', '.') }} €
                    </p>

                    <p>
                        <strong>Categoria:</strong>
                        {{ $artigo->categoria->categoria ?? 'Sem categoria' }}
                    </p>

                    <p>
                        <strong>Criado em:</strong>
                        {{ $artigo->created_at }}
                    </p>

                    <hr>

                    <div class="d-flex gap-2">
                        <a href="{{ route('artigos.edit', $artigo->id) }}"
                           class="btn btn-warning btn-sm">
                            Editar
                        </a>

                        <form action="{{ route('artigos.destroy', $artigo->id) }}"
                              method="POST">
                            @csrf
                            @method('DELETE')

                            <button class="btn btn-danger btn-sm"
                                    onclick="return confirm('Eliminar este artigo?')">
                                Eliminar
                            </button>
                        </form>
                    </div>

                </div>

            </div>

        </div>
    </div>

</div>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
