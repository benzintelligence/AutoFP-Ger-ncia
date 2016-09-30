using AutoFP.Gerencia.Domain.Entities.Localizacao;
using AutoFP.Gerencia.Domain.Interface.Factories.Localizacao;

namespace AutoFP.Gerencia.Domain.Factories.Localizacao
{
    public class EnderecoFactory : IEnderecoFactory
    {
        public Endereco CreateInstance(string rua, string numero, string bairro, string cep, string pontoReferencia, bool enderecoCobranca, string cidade, string uf, string complemento, string titulo = null)
        {
            return new Endereco(rua, numero, bairro, cep, pontoReferencia, enderecoCobranca, cidade, uf, complemento, titulo);
        }
    }
}