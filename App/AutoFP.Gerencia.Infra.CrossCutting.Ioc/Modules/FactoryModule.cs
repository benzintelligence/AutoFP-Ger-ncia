using AutoFP.Gerencia.Domain.Factories;
using AutoFP.Gerencia.Domain.Factories.Localizacao;
using AutoFP.Gerencia.Domain.Factories.Pessoa;
using AutoFP.Gerencia.Domain.Factories.Produto;
using AutoFP.Gerencia.Domain.Interface.Factories;
using AutoFP.Gerencia.Domain.Interface.Factories.Localizacao;
using AutoFP.Gerencia.Domain.Interface.Factories.Pessoa;
using AutoFP.Gerencia.Domain.Interface.Factories.Produto;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Factory;
using AutoFP.Gerencia.Infra.CrossCutting.Security.Interface.Factory;
using SimpleInjector;

namespace AutoFP.Gerencia.Infra.CrossCutting.Ioc.Modules
{
    internal static class FactoryModule
    {
        internal static void RegisterFactories(Container container)
        {
            // Localização
            container.Register<IEnderecoFactory, EnderecoFactory>(Lifestyle.Singleton);

            // Pessoa
            container.Register<IClienteFactory, ClienteFactory>(Lifestyle.Singleton);
            container.Register<IFornecedorFactory, FornecedorFactory>(Lifestyle.Singleton);
            container.Register<IPessoaJuridicaFactory, PessoaJuridicaFactory>(Lifestyle.Singleton);
            container.Register<IPessoaFisicaFactory, PessoaFisicaFactory>(Lifestyle.Singleton);

            // Produto
            container.Register<IPecaFactory, PecaFactory>(Lifestyle.Singleton);
            container.Register<IPosicaoPecaFactory, PosicaoPecaFactory>(Lifestyle.Singleton);

            // Veículo

            container.Register<ICategoriaPecaFactory, CategoriaPecaFactory>(Lifestyle.Singleton);
            container.Register<IEmailFactory, EmailFactory>(Lifestyle.Singleton);
            container.Register<IMarcaFactory, MarcaFactory>(Lifestyle.Singleton);
            container.Register<IMontadoraFactory, MontadoraFactory>(Lifestyle.Singleton);
            container.Register<ITelefoneFactory, TelefoneFactory>(Lifestyle.Singleton);

            container.Register<IUsuarioFactory, UsuarioFactory>(Lifestyle.Singleton);
        }
    }
}