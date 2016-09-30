(function() {
    'use strict';

    function populateEmail(email) {
        $('#colEmail').innerHTML = email;
    }

    function populateEndereco(ends) {
        $('#colCep_cobranca').innerHTML = ends[0].cep;
        $('#colLogradouro_cobranca').innerHTML = ends[0].logradouro;
        $('#colNumero_cobranca').innerHTML = ends[0].numero;
        $('#colComplemento_cobranca').innerHTML = ends[0].complemento;
        $('#colBairro_cobranca').innerHTML = ends[0].bairro;
        $('#colCidade_cobranca').innerHTML = ends[0].cidade;
        $('#colEstado_cobranca').innerHTML = ends[0].estado;
        $('#colPontoReferencia_cobranca').innerHTML = ends[0].pontoReferencia;

        $('#colCep_entrega').innerHTML = ends[1].cep;
        $('#colLogradouro_entrega').innerHTML = ends[1].logradouro;
        $('#colNumero_entrega').innerHTML = ends[1].numero;
        $('#colComplemento_entrega').innerHTML = ends[1].complemento;
        $('#colBairro_entrega').innerHTML = ends[1].bairro;
        $('#colCidade_entrega').innerHTML = ends[1].cidade;
        $('#colEstado_entrega').innerHTML = ends[1].estado;
        $('#colPontoReferencia_entrega').innerHTML = ends[1].pontoReferencia;
    }


})();