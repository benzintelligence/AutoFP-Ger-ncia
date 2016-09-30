using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.Interface.Factories
{
    public interface ITelefoneFactory
    {
        Telefone CreateInstance(int tipoTelefone, string numero);
    }
}