using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Factories;

namespace AutoFP.Gerencia.Domain.Factories
{
    public class EmailFactory : IEmailFactory
    {
        public Email CreateInstance(string email)
        {
            return new Email(email);
        }
    }
}