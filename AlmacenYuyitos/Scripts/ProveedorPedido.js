$(document).ready(function () {
    $("#PROVEEDORID").change(function () {

        $("#ORDENPEDIDOID").empty();

        $.getJSON("/DetallePedido/GetOrdenes", { PROVEEDORID: $("#PROVEEDORID").val() }, function (data) {
            $.each(data, function (index, row) {
                $("#ORDENPEDIDOID").append("<option value='" + this.Value + "'>" + this.Text + "</option>")
            });
        });
    });
});