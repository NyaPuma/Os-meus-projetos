<!DOCTYPE html>
<html lang="pt">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Gestão de Negócio</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body class="bg-light">

<div class="container mt-5 text-center">

    <h1 class="mb-5 fw-bold text-dark">Painel de Gestão</h1>

    <div class="row justify-content-center g-4">

        <!-- CLIENTES -->
        <div class="col-md-4">
            <div class="card h-100 shadow border-0">
                <div class="card-body py-5">
                    <h3 class="card-title fw-bold text-primary mb-3">Clientes</h3>
                    <p class="card-text text-muted mb-4">
                        Gerencie a listagem, estados e tipos de clientes da sua carteira.
                    </p>
                    <a href="{{ route('clientes.index') }}" class="btn btn-primary btn-lg px-4">
                        Abrir Clientes
                    </a>
                </div>
            </div>
        </div>

        <!-- FORNECEDORES -->
        <div class="col-md-4">
            <div class="card h-100 shadow border-0">
                <div class="card-body py-5">
                    <h3 class="card-title fw-bold text-secondary mb-3">Fornecedores</h3>
                    <p class="card-text text-muted mb-4">
                        Gerencie a listagem, NIFs e localizações dos seus fornecedores.
                    </p>
                    <a href="{{ route('fornecedores.index') }}" class="btn btn-secondary btn-lg px-4">
                        Abrir Fornecedores
                    </a>
                </div>
            </div>
        </div>

        <!-- PRODUTOS -->
        <div class="col-md-4">
            <div class="card h-100 shadow border-0">
                <div class="card-body py-5">
                    <h3 class="card-title fw-bold text-success mb-3">Produtos</h3>
                    <p class="card-text text-muted mb-4">
                        Gerencie o catálogo de artigos, referências, preços e controlo de stocks.
                    </p>
                    <a href="{{ route('produtos.index') }}" class="btn btn-success btn-lg px-4">
                        Abrir Produtos
                    </a>
                </div>
            </div>
        </div>

        <!-- ARTIGOS -->
        <div class="col-md-4">
            <div class="card h-100 shadow border-0">
                <div class="card-body py-5">
                    <h3 class="card-title fw-bold text-warning mb-3">Artigos</h3>
                    <p class="card-text text-muted mb-4">
                        Gerencie os artigos, descrições, preços, categorias e imagens.
                    </p>
                    <a href="{{ route('artigos.index') }}" class="btn btn-warning btn-lg px-4">
                        Abrir Artigos
                    </a>
                </div>
            </div>
        </div>

    </div>
</div>

</body>
</html>
