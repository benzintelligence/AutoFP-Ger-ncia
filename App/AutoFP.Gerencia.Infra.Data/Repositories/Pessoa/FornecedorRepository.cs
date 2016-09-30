using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Repositories.Pessoa;
using AutoFP.Gerencia.Infra.Data.Context;

namespace AutoFP.Gerencia.Infra.Data.Repositories.Pessoa
{
    public class FornecedorRepository: IFornecedorRepository
    {
        private readonly AutoFpContext _context;

        public FornecedorRepository(AutoFpContext context)
        {
            _context = context;
        }

        public Fornecedor GetById(Fornecedor fornecedor)
        {
            return _context.Fornecedores
                .Include(f => f.Pessoa)
                .Include(f => f.Pessoa.PessoaJuridica)
                .Include(f => f.Pessoa.Enderecos)
                .Include(f => f.Pessoa.Telefones)
                .Include(f => f.Pessoa.Email)
                .FirstOrDefault(x => x.FornecedorId == fornecedor.FornecedorId);
        }

        public IEnumerable<Fornecedor> GetAllForSelectList()
        {
            var resu = (from forn in _context.Fornecedores
                        join p in _context.Pessoas on forn.FornecedorId equals p.PessoaId
                        join pj in _context.PessoaJuridicas on p.PessoaId equals pj.PessoaJuridicaId
                        select new { forn.FornecedorId, pj.RazaoSocial })
                        .OrderBy(x => x.RazaoSocial)
                        .ToList();

            return resu.Select(f => new Fornecedor(f.FornecedorId)
            {
                Pessoa = new Domain.Entities.Pessoa.Pessoa
                {
                    PessoaJuridica = new PessoaJuridica(null, f.RazaoSocial)
                }
            });
        }

        public IEnumerable<Fornecedor> GetAll(int take, int skip)
        {
            var resu = (from forn in _context.Fornecedores
                        join p in _context.Pessoas on forn.FornecedorId equals p.PessoaId
                        join pj in _context.PessoaJuridicas on p.PessoaId equals pj.PessoaJuridicaId
                        select new { forn.FornecedorId, pj.Cnpj, pj.RazaoSocial })
                        .OrderBy(x => x.RazaoSocial)
                        .Skip(skip)
                        .Take(take)
                        .ToList();

            return resu.Select(f => new Fornecedor(f.FornecedorId)
            {
                Pessoa = new Domain.Entities.Pessoa.Pessoa
                {
                    PessoaJuridica = new PessoaJuridica(f.Cnpj, f.RazaoSocial)
                }
            });
        }

        public void Add(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
        }

        public void Update(Fornecedor fornecedor)
        {
            _context.Entry(fornecedor).State = EntityState.Modified;
        }

        public void Remove(Fornecedor fornecedor)
        {
            _context.Entry(fornecedor).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}