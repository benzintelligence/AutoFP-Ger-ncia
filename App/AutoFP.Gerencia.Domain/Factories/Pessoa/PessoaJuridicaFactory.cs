using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Factories.Pessoa;

namespace AutoFP.Gerencia.Domain.Factories.Pessoa
{
    public class PessoaJuridicaFactory : IPessoaJuridicaFactory
    {
        public PessoaJuridica CreateInstance(string cnpj, string razaoSocial, string nomeFantasia, string inscricaoMunicipal,
            string inscricaoEstadual, bool isento)
        {
            return new PessoaJuridica(cnpj, razaoSocial, nomeFantasia, inscricaoMunicipal, inscricaoEstadual, isento);
        }
    }
}