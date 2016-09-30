using AutoFP.Gerencia.Domain.Interface.Services;
using AutoFP.Gerencia.Domain.Interface.Services.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Services.Produto;
using AutoFP.Gerencia.Domain.Services;
using AutoFP.Gerencia.Domain.Services.Pessoa;
using AutoFP.Gerencia.Domain.Services.Produto;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Service;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Services;
using SimpleInjector;

namespace AutoFP.Gerencia.Infra.CrossCutting.Ioc.Modules
{
    internal static class ServiceModule
    {
        internal static void RegisterServices(Container container)
        {
            // Pessoa
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);

            // Produto
            container.Register<IPecaService, PecaService>(Lifestyle.Scoped);

            // Veículo
            // container.Register<ICarroService, CarroService>(Lifestyle.Scoped);
            // container.Register<IAnoModeloCarroService, AnoModeloCarroService>(Lifestyle.Scoped);

            container.Register<ICategoriaPecaService, CategoriaPecaService>(Lifestyle.Scoped);
            container.Register<IMarcaService, MarcaService>(Lifestyle.Scoped);
            container.Register<IMontadoraService, MontadoraService>(Lifestyle.Scoped);

            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
        }
    }
}