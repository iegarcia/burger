@Code
    ViewData("Title") = "Resumen"
End Code

<head>
    <meta charset="utf-8">
    <link href='~/Content/css/style.css' rel='stylesheet'>
    <title> Resumen De Tu Pedido</title>
    <link href="https://fonts.googleapis.com/css?family=Sen:700&display=swap" rel="stylesheet" />
    <link rel="stylesheet"
          href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"
          integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"
          crossorigin="anonymous" />
</head>

<body>
    <div class="titulo">
        <h2>
            <img src="~/Content/images/ham.svg" class="b-iCon">
            Resumen de tu pedido
            <img src="~/Content/images/ham.svg" class="b-iCon">
        </h2>
    </div>

    <table class="tabla">
        <tr>
            <td>Mexican</td>
            <td>$300</td>
            <td>1</td>
            <td>$300</td>
        </tr>
        <tr>
            <td>Mexican</td>
            <td>$300</td>
            <td>1</td>
            <td>$300</td>
        </tr>
        <tr>
            <td>Mexican</td>
            <td>$300</td>
            <td>1</td>
            <td>$300</td>
        </tr>
        <tr>
            <td style=background-color:crimson>Total a Pagar </td>
            <td style=background-color:coral> $300</td>
        </tr>
    </table>
    <br />
    <button class="btn btn-primary">Agregar Pedido</button>
</body>