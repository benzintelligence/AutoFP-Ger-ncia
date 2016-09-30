using AutoFP.Gerencia.Application.AppService.Base;
using AutoFP.Gerencia.Application.Factories;
using AutoFP.Gerencia.Application.Interface.Produto;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Peca;
using AutoFP.Gerencia.Application.ValueObjects.Validation;
using AutoFP.Gerencia.Domain.Interface.Factories.Produto;
using AutoFP.Gerencia.Domain.Interface.Services.Produto;
using AutoFP.Gerencia.Infra.Data.Interface;

namespace AutoFP.Gerencia.Application.AppService.Produto
{
    public class PecaAppService : BaseAppService, IPecaAppService
    {
        private readonly IPecaService _pecaService;
        private readonly IPecaFactory _pecaFactory;
        private readonly IPosicaoPecaFactory _posicaoPecaFactory;

        public PecaAppService(IUnitOfWork unitOfWork, IPecaService pecaService, IPecaFactory pecaFactory, IPosicaoPecaFactory posicaoPecaFactory)
            : base(unitOfWork)
        {
            _pecaService = pecaService;
            _pecaFactory = pecaFactory;
            _posicaoPecaFactory = posicaoPecaFactory;
        }

        public CreatePecaTo FillScreenElements(CreatePecaTo to = null)
        {
            return PecaAppFactory.FillScreenElements(_pecaService.FillScreenElements(), to);
        }

        public ValidationAppResult Add(CreatePecaTo to)
        {
            var peca = _pecaFactory.CreateInstance(to.CodigoDistribuidor, to.Nome, to.Descricao, to.Medida, to.PrecoDe, to.PrecoPara, to.Status, to.Original, to.ParalelaLinhaNumero, to.Importada, to.MarcaId, to.CategoriaPecaId,
                       _posicaoPecaFactory.CreateInstance(to.Posicao.LadoEsquerdo, to.Posicao.LadoDireito, to.Posicao.CodigoDianteiro, to.Posicao.CodigoTraseiro) );

            if (!peca.IsValid)
                return DomainToApplicationResult(peca.ValidationResult);

            BeginTransaction();
            _pecaService.Add(peca);
            Commit();
            return NewValidation();
        }

        public void Dispose()
        {
            _pecaService.Dispose();
        }
    }
}