using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Domain.Interface.Factories.Pessoa
{
    public interface IPessoaJuridicaFactory
    {
        PessoaJuridica CreateInstance(string cnpj, string razaoSocial, string nomeFantasia, string inscricaoMunicipal, string inscricaoEstadual, bool isento);
    }
}