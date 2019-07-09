$(function () {

});

$('#PROVEEDORID').on('change', function () {
    $('#detalle').html('');
});

$('#ORDENPEDIDOID').on('change', function () {
    var idOrden = $(this).find(":selected").text();
    getDatos(idOrden);
});

function getDatos(idOrden) {
    $.ajax({
        url: '/DetallePedido/GetDetalle',
        type: 'POST',
        data: { ordenId: idOrden },
        success: function (result) {
            $('#detalle').html(result);
        },
        error: function () {
        }
    });
}