using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Factory;

namespace AutoFP.Gerencia.Infra.CrossCutting.Security.Factory
{
    public class UsuarioFactory : IUsuarioFactory
    {
        public Usuario CreateInstance(string messageError)
        {
            var user = new Usuario();
            user.ValidationResult.AddError(messageError);
            return user;
        }

        public Usuario CreateInstance(string login, string senha)
        {
            var user = new Usuario();
            user.PreencherInformacoesParaLogin(login, senha);
            return user;
        }
    }
}