using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.Interface.Factories
{
    public interface ICategoriaPecaFactory
    {
        CategoriaPeca CreateInstance(int categoriaPecaId);

        CategoriaPeca CreateInstance(int categoriaPecaId, string descricao);

        CategoriaPeca CreateInstance(string descricao);
    }
}