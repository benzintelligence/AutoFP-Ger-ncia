using System;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.ValueObjects.Validation;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Factory;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Repository;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Service;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Scopes;

namespace AutoFP.Gerencia.Infra.CrossCutting.Security.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioFactory _usuarioFactory;

        public UsuarioService(IUsuarioRepository usuarioRepository, IUsuarioFactory usuarioFactory)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioFactory = usuarioFactory;
        }

        public Usuario GetByEmail(string email, string senha)
        {
            var usuario = _usuarioFactory.CreateInstance(email, senha);

            if (!usuario.IsValid)
                return usuario;

            return _usuarioRepository.ObterUsuarioAdministrador(usuario) ?? _usuarioFactory.CreateInstance(SecurityMessage.InvalidCredentials);
        }

        public Usuario Authenticate(string email, string password)
        {
            var user = GetByEmail(email, password);
            if (!user.IsValid)
                return user;

            user.LoginPasswordScopesIsValid(password);
            return user;
        }

        public ValidationResult Register(string email, string confirmEmail, string password, string confirmPassword)
        {
            throw new NotImplementedException();
        }

        public ValidationResult ChangePassword(string email, string oldPassword, string newPassword, string confirmNewPassword)
        {
            throw new NotImplementedException();
        }

        public string ResetPassword(string email, out ValidationResult validate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}