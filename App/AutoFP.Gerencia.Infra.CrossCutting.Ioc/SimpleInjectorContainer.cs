using AutoFP.Gerencia.Infra.CrossCutting.Ioc.Modules;
using SimpleInjector;

namespace AutoFP.Gerencia.Infra.CrossCutting.Ioc
{
    public static class SimpleInjectorContainer
    {
        public static void DependencyResolver(Container container)
        {
            DataAccessModule.RegisterDataAccess(container);
            ApplicationServiceModule.RegisterAppServices(container);
            FactoryModule.RegisterFactories(container);
            ServiceModule.RegisterServices(container);
            RepositoryModule.RegisterRepositories(container);
        }
    }
}