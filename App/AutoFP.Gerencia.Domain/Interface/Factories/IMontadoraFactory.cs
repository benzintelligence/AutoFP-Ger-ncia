using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.Interface.Factories
{
    public interface IMontadoraFactory
    {
        Montadora CreateInstance(int montadoraId);

        Montadora CreateInstance(string descricao, bool destacar);

        Montadora CreateInstance(int montadoraId, string descricao, bool destacar);
    }
}