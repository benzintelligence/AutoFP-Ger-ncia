using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Telefone;
using AutoFP.Gerencia.Domain.Entities;
using AutoFP.Gerencia.Domain.Interface.Factories;

namespace AutoFP.Gerencia.Application.ValueObjects.HelperMapping
{
    internal static class TelefoneMapping
    {
        internal static ICollection<Telefone> Mapping(IEnumerable<CreateTelefoneTo> to, ITelefoneFactory factory)
        {
            return to.Select(tel => factory.CreateInstance(tel.TipoTelefone, tel.Numero)).ToList();
        }
    }
}