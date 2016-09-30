using AutoFP.Gerencia.Domain.Entities.Produto;

namespace AutoFP.Gerencia.Domain.Interface.Factories.Produto
{
    public interface IGaleriaFactory
    {
        Galeria CreateInstance();
    }
}