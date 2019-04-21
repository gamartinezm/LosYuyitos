$(document).ready(function () {
    $("#REGIONID").change(function () {
        
        $("#COMUNAID").empty();

        $.getJSON("/Persona/GetComunas", { REGIONID: $("#REGIONID").val() }, function (data) {
            $.each(data, function (index, row) {
                $("#COMUNAID").append("<option value='" + this.Value + "'>" + this.Text + "</option>")
            });
        });
    });
});