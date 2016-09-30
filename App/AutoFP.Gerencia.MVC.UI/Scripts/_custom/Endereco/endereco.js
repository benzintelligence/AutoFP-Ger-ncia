function limparFormulario() {
    // Limpa valores do formulário de cep.
    $("#rua").val("");
    $("#complemento").val("");
    $("#bairro").val("");
    $("#cidade").val("");
    $("#uf").val("");
    $("#complemento").val("");
}

function limparFormulario2() {
    // Limpa valores do formulário de cep.
    $("#rua2").val("");
    $("#complemento2").val("");
    $("#bairro2").val("");
    $("#cidade2").val("");
    $("#uf2").val("");
    $("#complemento2").val("");
}

//Quando o campo cep perde o foco.
$("#cep").blur(function () {

    //Nova variável "cep" somente com dígitos.
    var cep = $(this).val().replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {
        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            $("#rua").val("Carregando...");
            $("#bairro").val("Carregando...");
            $("#cidade").val("Carregando...");
            $("#uf").val("Carregando...");
            $("#complemento").val("Carregando...");

            //Consulta o webservice viacep.com.br/
            $.getJSON("//viacep.com.br/ws/" + cep + "/json/", function (dados) {

                if (!("erro" in dados)) {
                    //Atualiza os campos com os valores da consulta.
                    $("#rua").val(dados.logradouro);
                    $("#bairro").val(dados.bairro);
                    $("#cidade").val(dados.localidade);
                    $("#uf").val(dados.uf);
                    $("#complemento").val(dados.complemento);
                } //end if.
                else {
                    //CEP pesquisado não foi encontrado.
                    limparFormulario();
                }
            });
        } //end if.
        else {
            //cep é inválido.
            limparFormulario();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limparFormulario();
    }
});

$("#cep2").blur(function () {

    //Nova variável "cep" somente com dígitos.
    var cep = $(this).val().replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {
        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            $("#rua2").val("Carregando...");
            $("#bairro2").val("Carregando...");
            $("#cidade2").val("Carregando...");
            $("#uf2").val("Carregando...");
            $("#complemento2").val("Carregando...");

            //Consulta o webservice viacep.com.br/
            $.getJSON("//viacep.com.br/ws/" + cep + "/json/", function (dados) {

                if (!("erro" in dados)) {
                    //Atualiza os campos com os valores da consulta.
                    $("#rua2").val(dados.logradouro);
                    $("#bairro2").val(dados.bairro);
                    $("#cidade2").val(dados.localidade);
                    $("#uf2").val(dados.uf);
                    $("#complemento2").val(dados.complemento);
                } //end if.
                else {
                    //CEP pesquisado não foi encontrado.
                    limparFormulario();
                }
            });
        } //end if.
        else {
            //cep é inválido.
            limparFormulario();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limparFormulario();
    }
});


function cobrancaEndereco(component) {
    if ($(component).is(':checked')) {
        $("#divEnderecoEntrega").hide();
    } else {
        $("#divEnderecoEntrega").show();
    }
}

cobrancaEndereco($("#IsEntrega"));

$("#IsEntrega").click(function () {
    cobrancaEndereco(this);
});