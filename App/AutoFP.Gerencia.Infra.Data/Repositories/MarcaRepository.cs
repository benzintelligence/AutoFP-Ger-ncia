using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Factories;
using AutoFP.Gerencia.Domain.Interface.Repositories;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;
using AutoFP.Gerencia.Infra.Data.Context;

namespace AutoFP.Gerencia.Infra.Data.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly AutoFpContext _context;
        private readonly IMarcaFactory _marcaFactory;

        public MarcaRepository(AutoFpContext context, IMarcaFactory marcaFactory)
        {
            _context = context;
            _marcaFactory = marcaFactory;
        }

        public MarcaDTO GetByIdForEdit(Marca marca)
        {
            // TODO: Puxar do banco de uma vez (Quando remover o Entity/Criar Stored Procedure)
            var categoriasPeca = _context.CategoriaPecas.OrderBy(x => x.Categoria);
            var mark = _context.Marcas.Find(marca.MarcaId);

            var dto = new MarcaDTO { MarcaId = mark.MarcaId, Marca = mark.Descricao, Destacar = mark.Destacar };
            foreach (var cp in categoriasPeca)
                dto.CategoriaPecas.Add(new CategoriaPeca(cp.CategoriaPecaId, cp.Categoria));

            return dto;
        }

        public Marca GetByIdForDetail(Marca marca)
        {
            return _context.Marcas.Include(x => x.CategoriaPecas).FirstOrDefault(x => x.MarcaId == marca.MarcaId);
        }

        public IEnumerable<Marca> GetAll(int take, int skip)
        {
            return _context.Marcas.OrderBy(x => !x.Destacar).ThenBy(x => x.Descricao).Skip(skip).Take(take);
        }

        public IEnumerable<Marca> GetMarcaByCategoriaPeca(CategoriaPeca categoriaPeca)
        {
            var dados = (from mark in _context.Marcas
                        .Where(x => x.CategoriaPecas.Any(c => c.CategoriaPecaId == categoriaPeca.CategoriaPecaId))
                        .OrderBy(m => m.Descricao)
                        select new { mark.MarcaId, MarcaNome = mark.Descricao }).ToList();

            return dados.Select(mark => _marcaFactory.CreateInstance(mark.MarcaId, mark.MarcaNome));
        }

        public void Add(Marca marca)
        {
            _context.Marcas.Add(marca);
        }

        public void AddCategories(Marca marca)
        {
            var sql = new StringBuilder();
            sql.Append("INSERT INTO MarcaCategoriaPeca VALUES");

            foreach (var categoriaPecaId in marca.CategoriasPecasIds)
                sql.AppendFormat("({0}, {1}),", categoriaPecaId, marca.MarcaId);

            _context.Database.ExecuteSqlCommand(sql.ToString().Remove(sql.Length - 1));
        }

        public void Update(Marca marca)
        {
            RemoveAllMarcaCategoriaPeca(marca);
            _context.Entry(marca).State = EntityState.Modified;
            AddCategories(marca);
        }

        public void Remove(Marca marca)
        {
            RemoveAllMarcaCategoriaPeca(marca);
            _context.Entry(marca).State = EntityState.Deleted;
        }

        private void RemoveAllMarcaCategoriaPeca(Marca marca)
        {
            _context.Database.ExecuteSqlCommand("DELETE FROM MarcaCategoriaPeca WHERE MarcaId=" + marca.MarcaId);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}