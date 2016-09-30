namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.Endereco
{
    public class CreateEnderecoTo
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string PontoReferencia { get; set; }

        public bool EnderecoCobranca { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public CreateEnderecoTo Copy()
        {
            return (CreateEnderecoTo) this.MemberwiseClone();
        }
    }
}