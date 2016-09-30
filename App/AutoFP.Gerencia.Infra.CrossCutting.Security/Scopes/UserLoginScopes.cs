using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.ValueObjects.Validation.ValidationAssertion;

namespace AutoFP.Gerencia.Infra.CrossCutting.Security.Scopes
{
    public static class UserLoginScopes
    {
        public static bool LoginPasswordScopesIsValid(this Usuario user, string password)
        {
            if (user.SenhaHash == PasswordAssertionConcern.Encrypt(password))
                return true;

            user.ValidationResult.AddError(SecurityMessage.InvalidCredentials);
            return false;
        }
    }
}