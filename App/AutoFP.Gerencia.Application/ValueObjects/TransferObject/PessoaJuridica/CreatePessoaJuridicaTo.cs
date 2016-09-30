namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.PessoaJuridica
{
    public class CreatePessoaJuridicaTo
    {
        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string InscricaoMunicipal { get; set; }

        public string InscricaoEstadual { get; set; }

        public bool Isento { get; set; }
    }
}