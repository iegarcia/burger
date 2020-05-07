﻿@Code
    ViewData("Title") = "Resumen"
    Layout = "~/Views/Shared/_HomeLayout.vbhtml"
End Code

<div class="titulo">
    <h2>
        <img src="~/Content/images/ham.svg"
             class="b-iCon"
             alt="BurgICon">
        Resumen de tu pedido
        <img src="~/Content/images/ham.svg"
             class="b-iCon"
             alt="BurgICon">
    </h2>
</div>
<br />
<div class="content">
    <table class="resumen">
        <tr>
            <th class="thead"></th>
            <th class="thead">Producto</th>
            <th class="thead">Precio</th>
            <th class="thead">Cantidad</th>
        </tr>
        <tr>
            <td><input type="checkbox" /></td>
            <td class="tbody">Mexican</td>
            <td class="tbody">$300</td>
            <td><input type="number" placeholder="0" /></td>
        </tr>
        <tr>
            <td><input type="checkbox" /></td>
            <td class="tbody">Fritas</td>
            <td class="tbody">$100</td>
            <td><input type="number" placeholder="0" /></td>
        </tr>
        <tr>
            <td><input type="checkbox" /></td>
            <td class="tbody">Cerveza</td>
            <td class="tbody">$50</td>
            <td><input type="number" placeholder="0" /></td>
        </tr>
    </table>
</div>
<hr />
<label>Total a Pagar</label>
<input type="text" placeholder="Total"/>&nbsp;
<a href="/Home/Index" class="btn btn-info">Agregar Pedido</a>
<a href="#" class="btn btn-success">Procesar Pago</a>

