using System;

namespace AutoFP.Gerencia.Infra.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void SaveChanges();
    }
}