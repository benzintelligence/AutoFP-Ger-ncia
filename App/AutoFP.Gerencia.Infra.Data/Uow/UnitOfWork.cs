using AutoFP.Gerencia.Infra.Data.Context;
using AutoFP.Gerencia.Infra.Data.Interface;

namespace AutoFP.Gerencia.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoFpContext _context;
        private bool _disposed;

        public UnitOfWork(AutoFpContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
    }
}