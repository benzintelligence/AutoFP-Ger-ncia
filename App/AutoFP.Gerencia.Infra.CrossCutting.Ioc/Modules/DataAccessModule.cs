using AutoFP.Gerencia.Infra.Data.Context;
using AutoFP.Gerencia.Infra.Data.Interface;
using AutoFP.Gerencia.Infra.Data.Uow;
using SimpleInjector;

namespace AutoFP.Gerencia.Infra.CrossCutting.Ioc.Modules
{
    internal static class DataAccessModule
    {
        internal static void RegisterDataAccess(Container container)
        {
            container.Register<AutoFpContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}