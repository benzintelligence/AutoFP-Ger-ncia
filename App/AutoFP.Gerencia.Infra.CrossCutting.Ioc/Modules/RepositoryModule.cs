using AutoFP.Gerencia.Domain.Interface.Repositories;
using AutoFP.Gerencia.Domain.Interface.Repositories.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Repositories.Produto;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Repository;
using AutoFP.Gerencia.Infra.Data.Repositories;
using AutoFP.Gerencia.Infra.Data.Repositories.Pessoa;
using AutoFP.Gerencia.Infra.Data.Repositories.Produto;
using SimpleInjector;

namespace AutoFP.Gerencia.Infra.CrossCutting.Ioc.Modules
{
    internal static class RepositoryModule
    {
        internal static void RegisterRepositories(Container container)
        {
            // Pessoa
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);

            // Produto
            container.Register<IPecaRepository, PecaRepository>(Lifestyle.Scoped);

            // Veículo
            // container.Register<ICarroRepository, CarroRepository>(Lifestyle.Scoped);
            // container.Register<IAnoModeloCarroRepository, AnoModeloCarroRepository>(Lifestyle.Scoped);

            container.Register<ICategoriaPecaRepository, CategoriaPecaRepository>(Lifestyle.Scoped);
            container.Register<IMarcaRepository, MarcaRepository>(Lifestyle.Scoped);
            container.Register<IMontadoraRepository, MontadoraRepository>(Lifestyle.Scoped);

            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
        }
    }
}