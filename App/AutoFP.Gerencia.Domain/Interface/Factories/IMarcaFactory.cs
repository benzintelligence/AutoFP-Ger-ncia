using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.Interface.Factories
{
    public interface IMarcaFactory
    {
        Marca CreateInstance(int marcaId);

        Marca CreateInstance(string descricao, bool destacar, int[] categoriasSelecionadasIds);

        Marca CreateInstance(int marcaId, string descricao);

        Marca CreateInstance(int marcaId, string descricao, bool destacar, int[] categoriasSelecionadasIds);
    }
}