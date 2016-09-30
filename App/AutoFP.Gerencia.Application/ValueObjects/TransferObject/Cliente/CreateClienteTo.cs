using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Email;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Endereco;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaFisica;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaJuridica;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Telefone;

namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.Cliente
{
    public class CreateClienteTo
    {
        public bool IsPessoaFisica { get; set; }

        public CreatePessoaFisicaTo Pf { get; set; }

        public CreatePessoaJuridicaTo Pj { get; set; }

        public CreateEmailTo Email { get; set; }

        public List<CreateEnderecoTo> Enderecos { get; set; }

        public IEnumerable<CreateTelefoneTo> Telefones { get; set; }
    }
}