using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.Interface.Factories.Produto;

namespace AutoFP.Gerencia.Domain.Factories.Produto
{
    public class PosicaoPecaFactory : IPosicaoPecaFactory
    {
        public PosicaoPeca CreateInstance(bool ladoEsquerdo, bool ladoDireito, string codigoDianteiro, string codigoTraseiro)
        {
            return new PosicaoPeca(ladoEsquerdo, ladoDireito, codigoDianteiro, codigoTraseiro);
        }
    }
}