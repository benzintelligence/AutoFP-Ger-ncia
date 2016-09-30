using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Factories;

namespace AutoFP.Gerencia.Domain.Factories
{
    public class MontadoraFactory : IMontadoraFactory
    {
        public Montadora CreateInstance(int montadoraId)
        {
            return new Montadora(montadoraId);
        }

        public Montadora CreateInstance(string descricao, bool destacar)
        {
            return new Montadora(descricao, destacar);
        }

        public Montadora CreateInstance(int montadoraId, string descricao, bool destacar)
        {
            return new Montadora(montadoraId, descricao, destacar);
        }
    }
}