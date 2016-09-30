using System;
using System.Linq;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Repository;
using AutoFP.Gerencia.Infra.Data.Context;

namespace AutoFP.Gerencia.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AutoFpContext _context;

        public UsuarioRepository(AutoFpContext context)
        {
            _context = context;
        }

        public Usuario ObterUsuarioAdministrador(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == usuario.Email && x.SenhaHash == usuario.SenhaHash && x.IsUserManagement);
        }

        public void Create(Usuario user)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}