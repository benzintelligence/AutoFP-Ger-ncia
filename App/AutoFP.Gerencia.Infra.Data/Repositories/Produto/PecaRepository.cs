using System.Linq;
using AutoFP.Gerencia.Domain.Entities.Produto;
using AutoFP.Gerencia.Domain.Interface.Repositories.Produto;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;
using AutoFP.Gerencia.Infra.Data.Context;

namespace AutoFP.Gerencia.Infra.Data.Repositories.Produto
{
    public class PecaRepository : IPecaRepository
    {
        private readonly AutoFpContext _context;

        public PecaRepository(AutoFpContext context)
        {
            _context = context;
        }

        public PecaDTO FillScreenElements()
        {
            // TODO: Puxar de uma única fez, ao migrar para ADO.net
            var marcas = (from ma in _context.Marcas.OrderBy(x => x.Descricao)
                          select new {ma.MarcaId, MarcaNome = ma.Descricao}).ToList();

            var categorias = (from c in _context.CategoriaPecas.OrderBy(x => x.Categoria)
                              select new { c.CategoriaPecaId, c.Categoria }).ToList();

            var montadoras = (from mo in _context.Montadoras.OrderBy(x => x.Descricao)
                              select new { mo.MontadoraId, mo.Descricao }).ToList();

            var dto = new PecaDTO();

            for (int i = 0; i < marcas.Count; i++)
                dto.Marcas.Add(marcas[i].MarcaNome, marcas[i].MarcaId);

            for (int i = 0; i < categorias.Count; i++)
                dto.CategoriasPecas.Add(categorias[i].Categoria, categorias[i].CategoriaPecaId);

            for (int i = 0; i < montadoras.Count; i++)
                dto.Montadoras.Add(montadoras[i].Descricao, montadoras[i].MontadoraId);

            return dto;
        }

        public void Add(Peca peca)
        {
            _context.Pecas.Add(peca);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}