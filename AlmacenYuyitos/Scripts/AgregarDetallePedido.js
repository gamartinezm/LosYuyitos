$(function () {
    $("#crear-orden").submit(function (e) {
        e.preventDefault();
        var actionurl = e.currentTarget.action;
        $.ajax({
            url: actionurl,
            type: 'post',
            dataType: 'json',
            data: $("#crear-orden").serialize(),
            success: function (response) {
                if (response.success) {
                    llenarTabla();
                } else {
                    console.log("error al ingresar el producto");
                }
            },
            error: function (response) {
                alert("ha ocurrido un error!");
            }
        });
    });
});

function llenarTabla() {
    var tipoProducto = $('#TIPOPRODUCTO_TIPOPRODUCTOID  option:selected').val();
    //var numOrden = $('#ORDENPEDIDO_ORDENPEDIDOID').text();
    var familiaProducto = $('#FAMILIAPRODUCTOID  option:selected').text();
    var cantidad = $('#CANTIDAD').val();
    var precio = $('#PRECIOCOMPRA').val();

    $('#detalle').append('<tr><td>' /*+ numOrden + '</td><td>'*/ + cantidad + '</td><td>' + familiaProducto + '</td><td>' + tipoProducto + '</td><td>' + "$ " + precio + '</td></tr>');

    //console.log(numOrden);
    console.log(tipoProducto);
    console.log(familiaProducto);
    console.log(cantidad);
    console.log(precio);
}