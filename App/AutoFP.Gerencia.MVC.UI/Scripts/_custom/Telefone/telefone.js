$("#TipoTelefone1").change(function () {
    if ($("option:selected", this).val() == 3)
        $("#telRamal1").prop("disabled", false);
    else
        $("#telRamal1").prop("disabled", true);
});

$("#TipoTelefone2").change(function () {
    if ($("option:selected", this).val() == 3)
        $("#telRamal2").prop("disabled", false);
    else
        $("#telRamal2").prop("disabled", true);
});

if ($("#TipoTelefone1 option:selected").val() == 3)
    $("#telRamal1").prop("disabled", false);

if ($("#TipoTelefone2 option:selected").val() == 3)
    $("#telRamal2").prop("disabled", false);