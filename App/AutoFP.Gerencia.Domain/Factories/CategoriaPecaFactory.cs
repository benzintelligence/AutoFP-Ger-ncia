using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Factories;

namespace AutoFP.Gerencia.Domain.Factories
{
    public class CategoriaPecaFactory : ICategoriaPecaFactory
    {
        public CategoriaPeca CreateInstance(int categoriaPecaId)
        {
            return new CategoriaPeca(categoriaPecaId);
        }

        public CategoriaPeca CreateInstance(int categoriaPecaId, string descricao)
        {
            return new CategoriaPeca(categoriaPecaId, descricao);
        }

        public CategoriaPeca CreateInstance(string descricao)
        {
            return new CategoriaPeca(descricao);
        }
    }
}