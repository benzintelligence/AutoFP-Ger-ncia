using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaFisica;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class PessoaFisicaAppFactory
    {
        public static CreatePessoaFisicaTo CreateInstance(string cpf, string nome, string sobrenome)
        {
            return new CreatePessoaFisicaTo
            {
                Cpf = cpf,
                Nome = nome,
                Sobrenome = sobrenome
            };
        }
    }
}