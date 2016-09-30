using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Repositories.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Services.Pessoa;

namespace AutoFP.Gerencia.Domain.Services.Pessoa
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public Fornecedor GetById(Fornecedor fornecedor)
        {
            return _fornecedorRepository.GetById(fornecedor);
        }

        public IEnumerable<Fornecedor> GetAllForSelectList()
        {
            return _fornecedorRepository.GetAllForSelectList();
        }

        public IEnumerable<Fornecedor> GetAll(int take, int skip)
        {
            return _fornecedorRepository.GetAll(take, skip);
        }

        public void Add(Fornecedor fornecedor)
        {
            _fornecedorRepository.Add(fornecedor);
        }

        public void Update(Fornecedor fornecedor)
        {
            _fornecedorRepository.Update(fornecedor);
        }

        public void Remove(Fornecedor fornecedor)
        {
            _fornecedorRepository.Remove(fornecedor);
        }

        public void Dispose()
        {
            _fornecedorRepository.Dispose();
        }
    }
}