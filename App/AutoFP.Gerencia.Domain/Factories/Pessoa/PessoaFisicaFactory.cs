using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Factories.Pessoa;

namespace AutoFP.Gerencia.Domain.Factories.Pessoa
{
    public class PessoaFisicaFactory : IPessoaFisicaFactory
    {
        public PessoaFisica CreateInstance(string cpf, string nome, string sobrenome)
        {
            return new PessoaFisica(cpf, nome, sobrenome);
        }
    }
}