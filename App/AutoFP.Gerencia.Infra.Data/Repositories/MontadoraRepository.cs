using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Repositories;
using AutoFP.Gerencia.Infra.Data.Context;

namespace AutoFP.Gerencia.Infra.Data.Repositories
{
    public sealed class MontadoraRepository : IMontadoraRepository
    {
        private readonly AutoFpContext _context;

        public MontadoraRepository(AutoFpContext context)
        {
            _context = context;
        }

        public IEnumerable<Montadora> GetAll(int take, int skip)
        {
            return _context.Montadoras.OrderBy(x => !x.Destacar).ThenBy(x => x.Descricao).Skip(skip).Take(take);
        }

        public IEnumerable<Montadora> GetAllForSelectList()
        {
            var dados = (from montadora in _context.Montadoras.OrderBy(x => !x.Destacar).ThenBy(x => x.Descricao)
                         select new { montadora.MontadoraId, montadora.Descricao })
                         .ToList();

            return dados.Select(montadora => new Montadora(montadora.MontadoraId, montadora.Descricao, false));
        }

        public Montadora GetById(Montadora montadora)
        {
            return _context.Montadoras.Find(montadora.MontadoraId);
        }

        public void Add(Montadora montadora)
        {
            _context.Montadoras.Add(montadora);
        }

        public void Update(Montadora montadora)
        {
            _context.Entry(montadora).State = EntityState.Modified;
        }

        public void Remove(Montadora montadora)
        {
            _context.Entry(montadora).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}