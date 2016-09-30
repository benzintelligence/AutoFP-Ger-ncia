namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.PosicaoPeca
{
    public class CreatePosicaoPecaTo
    {
        public bool LadoEsquerdo { get; set; }

        public bool LadoDireito { get; set; }

        public string CodigoDianteiro { get; set; }

        public string CodigoTraseiro { get; set; }
    }
}