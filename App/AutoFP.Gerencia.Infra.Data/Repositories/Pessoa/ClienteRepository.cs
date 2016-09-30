using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Repositories.Pessoa;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject.Cliente;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject.Endereco;
using AutoFP.Gerencia.Domain.ValueObjects.Enums;
using AutoFP.Gerencia.Infra.Data.Context;

namespace AutoFP.Gerencia.Infra.Data.Repositories.Pessoa
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AutoFpContext _context;

        public ClienteRepository(AutoFpContext context)
        {
            _context = context;
        }

        public ClienteDTO ObterClienteViaCpf(string cpf)
        {
            return new ClienteDTO
            {
                clienteId = 1,
                cliente = "Paulo Rodrigues",
                cpf = cpf,
                email = "pauloroberto.prrl@gmail.com",
                Telefones = new List<TelefoneDTO>
                {
                    new TelefoneDTO { numero = "11 2566-0030", tipoTelefone = "Fixo" },
                    new TelefoneDTO { numero = "11 99653-2953", tipoTelefone = "Celular" }
                },
                Enderecos = new List<EnderecoDTO>
                {
                    new EnderecoDTO
                    {
                        cep = "08141-340",
                        bairro = "Chácara Dona Olívia",
                        cidade = "São Paulo",
                        complemento = "",
                        estado = "SP",
                        logradouro = "Rua Manuel Nunes Figueira",
                        numero = "190",
                        pontoReferencia = "Supermercado Higa's"
                    },
                    new EnderecoDTO
                    {
                        cep = "08141-340",
                        bairro = "Chácara Dona Olívia",
                        cidade = "São Paulo",
                        complemento = "",
                        estado = "SP",
                        logradouro = "Rua Manuel Nunes Figueira",
                        numero = "133",
                        pontoReferencia = "Supermercado Higa's"
                    }
                }
            };
        }

        public ClienteDTO ObterClienteViaCnpj(string cnpj)
        {
            return new ClienteDTO
            {
                clienteId = 1,
                cnpj = cnpj,
                razaoSocial = "AutoFP",
                nomeFantasia = "AutoFP - Comércio de peças automotivas",
                inscricaoEstadual = "8248882484",
                inscricaoMunicipal = "",
                email = "pauloroberto.prrl@gmail.com",
                Telefones = new List<TelefoneDTO>
                {
                    new TelefoneDTO { numero = "11 2566-0030", tipoTelefone = "Fixo" },
                    new TelefoneDTO { numero = "11 99653-2953", tipoTelefone = "Celular" }
                },
                Enderecos = new List<EnderecoDTO>
                {
                    new EnderecoDTO
                    {
                        cep = "08141-340",
                        bairro = "Chácara Dona Olívia",
                        cidade = "São Paulo",
                        complemento = "",
                        estado = "SP",
                        logradouro = "Rua Manuel Nunes Figueira",
                        numero = "190",
                        pontoReferencia = "Supermercado Higa's"
                    },
                    new EnderecoDTO
                    {
                        cep = "08141-340",
                        bairro = "Chácara Dona Olívia",
                        cidade = "São Paulo",
                        complemento = "",
                        estado = "SP",
                        logradouro = "Rua Manuel Nunes Figueira",
                        numero = "133",
                        pontoReferencia = "Supermercado Higa's"
                    }
                }
            };
        }

        public IEnumerable<ListClientesDTO> GetAll(int take, int skip)
        {
            var resu = (from client in _context.Clientes
                        join p in _context.Pessoas on client.ClienteId equals p.PessoaId
                        join pf in _context.PessoaFisicas on p.PessoaId equals pf.PessoaFisicaId
                        join pj in _context.PessoaJuridicas on p.PessoaId equals pj.PessoaJuridicaId
                        select new
                        {
                            client.ClienteId, p.TipoPessoa, pf.Nome, pf.Sobrenome, pj.RazaoSocial
                        })
                        .OrderBy(x => x.ClienteId)
                        .Take(take)
                        .Skip(skip)
                        .ToList();

            return resu.Select(x => new ListClientesDTO
            {
                ClienteId = x.ClienteId,
                Cliente = x.TipoPessoa.Equals((int)TipoPessoa.PersonPhysical)
                                      ? x.Nome + " " + x.Sobrenome
                                      : x.RazaoSocial,
                TipoPessoa = x.TipoPessoa.Equals((int)TipoPessoa.PersonPhysical) ? "Pessoa física" : "Pessoa jurídica"
            });
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}