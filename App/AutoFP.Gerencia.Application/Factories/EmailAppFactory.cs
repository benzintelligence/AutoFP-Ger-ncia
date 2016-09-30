using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Email;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class EmailAppFactory
    {
        public static CreateEmailTo CreateInstance(string email)
        {
            return new CreateEmailTo { Email = email };
        }
    }
}