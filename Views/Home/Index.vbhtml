﻿@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_HomeLayout.vbhtml"
End Code

<div class="home-section">
    <h1 class="home-title">Bienvenido a la hamburgueseria</h1>
    <p class="home-description">
        Lorem no molestie et lorem est et amet rebum et ipsum delenit justo diam ipsum lorem enim vero sea takimata invidunt diam et vel sed kasd dolore at dolore imperdiet elitr diam dolor stet tempor dolore illum vel nonumy vero sit sadipscing labore dolores sadipscing facilisis gubergren aliquip aliquam illum
        </p>
    <hr />
    <h3 class="prod-sell">A continuacion elija un producto</h3>
</div>
<br />
<br />
<div class="box">
    <img src="~/Content/images/burger01.jpg" alt="mexicana" />
    <img src="~/Content/images/burger02.jpg" alt="jamaica" />
    <img src="~/Content/images/burger03.jpg" alt="classic" />
    <img src="~/Content/images/burger04.jpg" alt="veggie" />
</div>
<br />
<table class="t-prod">
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
<a href="/Resumen" class="btn btn-primary">Pedir</a>
