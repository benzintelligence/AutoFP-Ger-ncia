function tipoPessoa() {
    if ($("#rdnPF").is(':checked')) {
        $("#divPessoaJuridica").hide();
        $("#divPessoaFisica").show();
    } else {
        $("#divPessoaFisica").hide();
        $("#divPessoaJuridica").show();
    }
}

tipoPessoa();

$(".gpTipoPessoa").click(function () {
    tipoPessoa();
});