﻿using System;
using System.Collections.Generic;
using AutoFP.Gerencia.Domain.Entities.Pessoa;

namespace AutoFP.Gerencia.Domain.Interface.Services.Pessoa
{
    public interface IFornecedorService : IDisposable
    {
        Fornecedor GetById(Fornecedor fornecedor);

        IEnumerable<Fornecedor> GetAllForSelectList();

        IEnumerable<Fornecedor> GetAll(int take, int skip);

        void Add(Fornecedor fornecedor);

        void Update(Fornecedor fornecedor);

        void Remove(Fornecedor fornecedor);
    }
}