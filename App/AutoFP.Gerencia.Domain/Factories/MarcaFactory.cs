using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Factories;

namespace AutoFP.Gerencia.Domain.Factories
{
    public class MarcaFactory : IMarcaFactory
    {
        public Marca CreateInstance(int marcaId)
        {
            return new Marca(marcaId);
        }

        public Marca CreateInstance(string descricao, bool destacar, int[] categoriasSelecionadasIds)
        {
            return new Marca(descricao, destacar, categoriasSelecionadasIds);
        }

        public Marca CreateInstance(int marcaId, string descricao)
        {
            return new Marca(marcaId, descricao);
        }

        public Marca CreateInstance(int marcaId, string descricao, bool destacar, int[] categoriasSelecionadasIds)
        {
            return new Marca(marcaId, descricao, destacar, categoriasSelecionadasIds);
        }
    }
}