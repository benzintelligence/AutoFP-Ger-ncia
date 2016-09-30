using AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaJuridica;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class PessoaJuridicaAppFactory
    {
        public static CreatePessoaJuridicaTo CreateInstance(string cnpj, string razaoSocial, string nomeFantasia, string inscricaoMunicipal, string inscricaoEstadual, bool isento)
        {
            return new CreatePessoaJuridicaTo
            {
                Cnpj = cnpj,
                RazaoSocial = razaoSocial,
                NomeFantasia = nomeFantasia,
                InscricaoMunicipal = inscricaoMunicipal,
                InscricaoEstadual = inscricaoEstadual,
                Isento = isento
            };
        }
    }
}