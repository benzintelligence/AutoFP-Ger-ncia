using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Domain.Interface.Factories.Pessoa
{
    public interface IPessoaFisicaFactory
    {
        PessoaFisica CreateInstance(string cpf, string nome, string sobrenome);
    }
}