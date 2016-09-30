using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Endereco;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class EnderecoAppFactory
    {
        public static CreateEnderecoTo CreateInstance(string rua, string numero, string bairro, string cep, string pontoReferencia, string cidade, string uf, string complemento, bool enderecoCobranca = false)
        {
            return new CreateEnderecoTo
            {
                Logradouro = rua,
                Numero = numero,
                Bairro = bairro,
                Cep = cep,
                PontoReferencia = pontoReferencia,
                Cidade = cidade,
                Uf = uf,
                Complemento = complemento,
                EnderecoCobranca = enderecoCobranca
            };
        }
    }
}