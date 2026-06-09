<!DOCTYPE html>
<html lang="pt">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Editar Artigo</title>

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
                <h1 class="mb-0">Editar artigo</h1>
            </div>
        </div>

        {{-- CARD --}}
        <div class="card shadow">
            <div class="card-body">

                <form action="{{ route('artigos.update', $artigo->id) }}" method="POST" enctype="multipart/form-data">

                    @csrf
                    @method('PUT')

                    {{-- DESCRIÇÃO + PREÇO --}}
                    <div class="row">

                        <div class="col-md-8 mb-3">
                            <label class="form-label">Descrição</label>
                            <input type="text" name="descricao"
                                class="form-control @error('descricao') is-invalid @enderror"
                                value="{{ old('descricao', $artigo->descricao) }}">

                            @error('descricao')
                                <div class="invalid-feedback">{{ $message }}</div>
                            @enderror
                        </div>

                        <div class="col-md-4 mb-3">
                            <label class="form-label">Preço</label>
                            <input type="number" step="0.01" name="preco"
                                class="form-control @error('preco') is-invalid @enderror"
                                value="{{ old('preco', $artigo->preco) }}">

                            @error('preco')
                                <div class="invalid-feedback">{{ $message }}</div>
                            @enderror
                        </div>

                    </div>

                    {{-- CARACTERÍSTICAS --}}
                    <div class="mb-3">
                        <label class="form-label">Características</label>
                        <textarea name="caracteristicas" class="form-control" rows="3">{{ old('caracteristicas', $artigo->caracteristicas) }}</textarea>
                    </div>

                    {{-- CATEGORIA + FOTO --}}
                    <div class="row">

                        <div class="col-md-6 mb-3">
                            <label class="form-label">Categoria</label>

                            <select name="categoria_id" class="form-select @error('categoria_id') is-invalid @enderror">

                                @foreach ($categorias as $categoria)
                                    <option value="{{ $categoria->id }}"
                                        {{ old('categoria_id', $artigo->categoria_id) == $categoria->id ? 'selected' : '' }}>
                                        {{ $categoria->categoria }}
                                    </option>
                                @endforeach

                            </select>

                            @error('categoria_id')
                                <div class="invalid-feedback">{{ $message }}</div>
                            @enderror
                        </div>

                        <div class="col-md-6 mb-3">
                            <label class="form-label">Foto</label>

                            <input type="file" name="foto" class="form-control">

                            @if ($artigo->foto)
                            <label class="form-label">Foto Atual</label>
                            <div class="mt-2">
                                    <img src="{{ asset('storage/' . $artigo->foto) }}" width="80" height="80"
                                        class="rounded" style="object-fit: cover;">
                                </div>
                            @endif
                        </div>

                    </div>

                    <hr>

                    {{-- BUTTONS --}}
                    <div class="d-flex gap-2">
                        <button type="submit" class="btn btn-success">
                            Guardar Alteração
                        </button>

                        <a href="{{ route('artigos.index') }}" class="btn btn-secondary">
                            Cancelar
                        </a>
                    </div>

                </form>

            </div>
        </div>

    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>

</html>
