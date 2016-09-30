using AutoFP.Gerencia.Domain.Entities.Localizacao;

namespace AutoFP.Gerencia.Domain.Interface.Factories.Localizacao
{
    public interface IEnderecoFactory
    {
        Endereco CreateInstance(string rua, string numero, string bairro, string cep, string pontoReferencia, bool enderecoCobranca, string cidade, string uf, string complemento, string titulo = null);
    }
}