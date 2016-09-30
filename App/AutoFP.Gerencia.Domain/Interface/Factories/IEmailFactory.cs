using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Domain.Interface.Factories
{
    public interface IEmailFactory
    {
        Email CreateInstance(string email);
    }
}