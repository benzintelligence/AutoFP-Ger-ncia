using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Repositories;
using AutoFP.Gerencia.Infra.Data.Context;

namespace AutoFP.Gerencia.Infra.Data.Repositories
{
    public sealed class CategoriaPecaRepository : ICategoriaPecaRepository
    {
        private readonly AutoFpContext _context;

        public CategoriaPecaRepository(AutoFpContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoriaPeca> ObterCategoriasPecasParaListaSelecionar()
        {
            return _context.CategoriaPecas.OrderBy(x => x.Categoria).AsNoTracking();
        }

        public IEnumerable<CategoriaPeca> GetAll(int take, int skip)
        {
            return _context.CategoriaPecas.OrderBy(x => x.Categoria).Skip(skip).Take(take).AsNoTracking();
        }

        public CategoriaPeca GetById(CategoriaPeca categoriaPeca)
        {
            return _context.CategoriaPecas.Find(categoriaPeca.CategoriaPecaId);
        }

        public void Add(CategoriaPeca categoriaPeca)
        {
            _context.CategoriaPecas.Add(categoriaPeca);
        }

        public void Update(CategoriaPeca categoriaPeca)
        {
            _context.Entry(categoriaPeca).State = EntityState.Modified;
        }

        public void Remove(CategoriaPeca categoriaPeca)
        {
            _context.Entry(categoriaPeca).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}