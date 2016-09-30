using System;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Peca;
using AutoFP.Gerencia.Application.ValueObjects.Validation;

namespace AutoFP.Gerencia.Application.Interface.Produto
{
    public interface IPecaAppService : IDisposable
    {
        CreatePecaTo FillScreenElements(CreatePecaTo to = null);

        ValidationAppResult Add(CreatePecaTo pecaTo);
    }
}