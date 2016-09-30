namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.Marca
{
    public class CreateMarcaTo
    {
        public string Descricao { get; set; }

        public bool Destacar { get; set; }

        public int[] CategoriasSelecionadasIds { get; set; }
    }
}