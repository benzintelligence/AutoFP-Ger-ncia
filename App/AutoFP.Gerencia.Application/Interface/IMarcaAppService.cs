using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Marca;
using AutoFP.Gerencia.Application.ValueObjects.Validation;

namespace AutoFP.Gerencia.Application.Interface
{
    public interface IMarcaAppService : IDisposable
    {
        UpdateMarcaTo GetByIdForEdit(int id);

        DetailMarcaTo GetByIdForDetail(int id);

        IEnumerable<ListMarcaTo> GetAll(int take, int skip);

        IEnumerable<ListMarcaTo> GetMarcaByCategoriaPeca(int categoriaPecaId);

        ValidationAppResult Add(CreateMarcaTo to);

        ValidationAppResult Update(UpdateMarcaTo to);

        ValidationAppResult Remove(int id);
    }
}