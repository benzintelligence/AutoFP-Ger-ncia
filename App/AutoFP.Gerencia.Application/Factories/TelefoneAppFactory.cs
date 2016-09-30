using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Telefone;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class TelefoneAppFactory
    {
        public static CreateTelefoneTo CreateInstance(int tipoTelefone, string numero)
        {
            return new CreateTelefoneTo
            {
                TipoTelefone = tipoTelefone, Numero = numero
            };
        }
    }
}