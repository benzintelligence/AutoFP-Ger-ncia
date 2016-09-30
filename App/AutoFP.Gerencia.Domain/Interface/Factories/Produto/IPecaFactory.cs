using AutoFP.Gerencia.Domain.Entities.Produto;

namespace AutoFP.Gerencia.Domain.Interface.Factories.Produto
{
    public interface IPecaFactory
    {
        Peca CreateInstance(string codigoDistribuidor, string nome, string descricao, string medida, decimal precoDe, decimal precoPara, int status, bool original, int? paralelaLinhaNumero, bool importada, int marcaId, int categoriaPecaId, PosicaoPeca posicionamento);
    }
}