using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Montadora;
using AutoFP.Gerencia.Application.ValueObjects.Validation;

namespace AutoFP.Gerencia.Application.Interface
{
    public interface IMontadoraAppService : IDisposable
    {
        UpdateMontadoraTo GetById(int id);

        IEnumerable<ListMontadoraTo> GetAllForSelectList();

        IEnumerable<ListMontadoraTo> GetAll(int take, int skip);

        ValidationAppResult Add(CreateMontadoraTo viewModel);

        ValidationAppResult Update(UpdateMontadoraTo viewModel);

        ValidationAppResult Remove(int id);
    }
}