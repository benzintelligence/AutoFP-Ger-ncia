using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Peca;
using AutoFP.Gerencia.Domain.ValueObjects.DataTransferObject;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class PecaAppFactory
    {
        public static CreatePecaTo FillScreenElements(PecaDTO dto, CreatePecaTo to = null)
        {
            return to == null
                ? FillElements(dto, new CreatePecaTo())
                : FillElements(dto, to);
        }

        private static CreatePecaTo FillElements(PecaDTO dto, CreatePecaTo to)
        {
            to.Marcas = dto.Marcas;
            to.Montadoras = dto.Montadoras;
            to.CategoriasPecas = dto.CategoriasPecas;
            return to;
        }

    }
}