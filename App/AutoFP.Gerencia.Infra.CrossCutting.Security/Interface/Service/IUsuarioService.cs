using System;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;

namespace AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Service
{
    public interface IUsuarioService : IDisposable
    {
        Usuario GetByEmail(string email, string senha);

        Usuario Authenticate(string email, string password);

        ValidationResult Register(string email, string confirmEmail, string password, string confirmPassword);

        ValidationResult ChangePassword(string email, string oldPassword, string newPassword, string confirmNewPassword);

        string ResetPassword(string email, out ValidationResult validate);
    }
}