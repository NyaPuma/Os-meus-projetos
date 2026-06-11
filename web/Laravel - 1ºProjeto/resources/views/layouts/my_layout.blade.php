<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>@yield('titulo')</title>
</head>
<body>

    <div class='container'>
        <h1>Menu</h1>
        @yield('menu')
    </div>

    <div class='container'>
        <h1>Conteudo da minha página</h1>
        @yield('conteudo')
    </div>

</body>
</html>
