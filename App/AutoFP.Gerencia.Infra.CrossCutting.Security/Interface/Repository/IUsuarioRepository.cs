using System;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Repository
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterUsuarioAdministrador(Usuario usuario);

        void Create(Usuario user);

        void Update(Usuario user);
    }
}