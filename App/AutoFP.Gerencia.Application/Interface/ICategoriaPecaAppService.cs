using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.CategoriaPeca;
using AutoFP.Gerencia.Application.ValueObjects.Validation;

namespace AutoFP.Gerencia.Application.Interface
{
    public interface ICategoriaPecaAppService : IDisposable
    {
        UpdateCategoriaPecaTo GetById(int id);

        IEnumerable<SelectListCategoriaPecaTo> ObterCategoriasPecasParaListaSelecionar();

        IEnumerable<ListCategoriaPecaTo> GetAll(int take, int skip);

        ValidationAppResult Add(CreateCategoriaPecaTo to);

        ValidationAppResult Update(UpdateCategoriaPecaTo to);

        ValidationAppResult Remove(int id);
    }
}