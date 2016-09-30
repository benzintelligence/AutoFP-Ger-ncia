$("#Isento").click(function () {
    if ($(this).is(":checked")) $("#InscricaoEstadual").prop("disabled", true);
    else $("#InscricaoEstadual").prop("disabled", false);
});

// Caso retorne para a tela, deixa o campo Inscrição estadual desabilitado ao carregar a página
if ($("#Isento").is(":checked")) $("#InscricaoEstadual").prop("disabled", true);