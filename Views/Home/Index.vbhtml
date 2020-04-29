<!DOCTYPE html>
<html lang="es" dir="ltr">
<head>
    <meta charset="utf-8" />
    <link
    rel="stylesheet"
    href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"
    integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"
    crossorigin="anonymous"
    />
    <link rel="stylesheet" href="~/Content/css/style.css" />
    <title>Hamburgueseria</title>
</head>
<body>
    <nav class="navbar navbar-light bg-light">
        <a class="navbar-brand" href="index.html"><img src="" alt="Logo" /> </a>
    </nav>
    <br />
    <div class="container">
        <div class="box">
            <img src="~/Content/images/burger01.jpg" alt="mexicana" />
            <img src="~/Content/images/burger02.jpg" alt="jamaica" />
            <img src="~/Content/images/burger03.jpg" alt="classic" />
            <img src="~/Content/images/burger04.jpg" alt="veggie" />
        </div>
        <br />
        <table>
            <tr>
                <td>Mexicana</td>
                <td>Jamaica</td>
                <td>Clasica</td>
                <td>Vegana</td>
            </tr>
            <tr>
                <td>$300</td>
                <td>$350</td>
                <td>$290</td>
                <td>$275</td>
            </tr>
        </table>

        <br />
        <p>Total:</p>
        <button class="btn btn-primary">Pedir</button>
    </div>
</body>
</html>
