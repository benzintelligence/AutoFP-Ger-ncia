using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Fornecedor;
using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class FornecedorAppFactory
    {
        public static CreateFornecedorTo CreateInstance()
        {
            return new CreateFornecedorTo();
        }

        public static IEnumerable<ListFornecedorTo> CreateListInstance(IEnumerable<Fornecedor> listCategoriaPecas)
        {
            return listCategoriaPecas.Select(cp => new ListFornecedorTo
            {
                FornecedorId = cp.FornecedorId,
                Cnpj = cp.Pessoa.PessoaJuridica.Cnpj,
                RazaoSocial = cp.Pessoa.PessoaJuridica.RazaoSocial
            });
        }

        public static IEnumerable<SelectListFornecedorTo> CreateSelectListInstance(IEnumerable<Fornecedor> listCategoriaPecas)
        {
            return listCategoriaPecas.Select(to => new SelectListFornecedorTo
            {
                FornecedorId = to.FornecedorId,
                RazaoSocial = to.Pessoa.PessoaJuridica.RazaoSocial
            });
        }
    }
}