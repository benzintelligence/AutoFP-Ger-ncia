using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Email;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Endereco;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaJuridica;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Telefone;

namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.Fornecedor
{
    public class CreateFornecedorTo
    {
        public CreatePessoaJuridicaTo Pj { get; set; }

        public CreateEmailTo Email { get; set; }

        public CreateEnderecoTo Endereco { get; set; }

        public IEnumerable<CreateTelefoneTo> Telefones { get; set; }
    }
}