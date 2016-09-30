using AutoFP.Gerencia.Application.AppService;
using AutoFP.Gerencia.Application.AppService.Pessoa;
using AutoFP.Gerencia.Application.AppService.Produto;
using AutoFP.Gerencia.Application.Interface;
using AutoFP.Gerencia.Application.Interface.Pessoa;
using AutoFP.Gerencia.Application.Interface.Produto;
using SimpleInjector;

namespace AutoFP.Gerencia.Infra.CrossCutting.Ioc.Modules
{
    internal static class ApplicationServiceModule
    {
        internal static void RegisterAppServices(Container container)
        {
            // Pessoa
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IFornecedorAppService, FornecedorAppService>(Lifestyle.Scoped);

            // Produto
            container.Register<IPecaAppService, PecaAppService>(Lifestyle.Scoped);

            container.Register<ICategoriaPecaAppService, CategoriaPecaAppService>(Lifestyle.Scoped);
            container.Register<IMarcaAppService, MarcaAppService>(Lifestyle.Scoped);
            container.Register<IMontadoraAppService, MontadoraAppService>(Lifestyle.Scoped);
        }
    }
}