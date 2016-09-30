using AutoFP.Gerencia.Domain.Entities.Produto;

namespace AutoFP.Gerencia.Domain.Interface.Factories.Produto
{
    public interface IPosicaoPecaFactory
    {
        PosicaoPeca CreateInstance(bool ladoEsquerdo, bool ladoDireito, string codigoDianteiro, string codigoTraseiro);
    }
}