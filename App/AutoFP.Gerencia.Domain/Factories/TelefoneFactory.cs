using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Factories;

namespace AutoFP.Gerencia.Domain.Factories
{
    public class TelefoneFactory : ITelefoneFactory
    {
        public Telefone CreateInstance(int tipoTelefone, string numero)
        {
            return new Telefone(tipoTelefone, numero);
        }
    }
}