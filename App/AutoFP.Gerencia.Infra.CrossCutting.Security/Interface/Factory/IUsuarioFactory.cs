using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Factory
{
    public interface IUsuarioFactory
    {
        Usuario CreateInstance(string messageError);

        Usuario CreateInstance(string login, string senha);
    }
}