$(document).ready(function () {
    $("#Region").change(function () {
        
        $("#Comuna").empty();

        $.getJSON("/Persona/GetComunas", { RegionId: $("#Region").val() }, function (data) {
            $.each(data, function (index, row) {
                $("#Comuna").append("<option value='" + this.Value + "'>" + this.Text + "</option>")
            });
        });
    });
});