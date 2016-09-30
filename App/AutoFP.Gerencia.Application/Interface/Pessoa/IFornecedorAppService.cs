using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Fornecedor;
using AutoFP.Gerencia.Application.ValueObjects.Validation;

namespace AutoFP.Gerencia.Application.Interface.Pessoa
{
    public interface IFornecedorAppService : IDisposable
    {
        IEnumerable<SelectListFornecedorTo> GetAllForSelectList();

        IEnumerable<ListFornecedorTo> GetAll(int take, int skip);

        ValidationAppResult Add(CreateFornecedorTo to);
    }
}