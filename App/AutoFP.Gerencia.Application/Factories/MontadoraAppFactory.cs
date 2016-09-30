using System.Collections.Generic;
using System.Linq;
using AutoFP.Gerencia.Application.ValueObjects.TransferObject.Montadora;
using AutoFP.Gerencia.Domain.Entities;

namespace AutoFP.Gerencia.Application.Factories
{
    public static class MontadoraAppFactory
    {
        public static CreateMontadoraTo CreateInstance(string montadora, bool destacar)
        {
            return new CreateMontadoraTo
            {
                Montadora = montadora, Destacar = destacar
            };
        }

        public static UpdateMontadoraTo CreateInstance(int montadoraId, string montadora, bool destacar)
        {
            return new UpdateMontadoraTo
            {
                MontadoraId = montadoraId,
                Montadora = montadora,
                Destacar = destacar
            };
        }

        public static IEnumerable<ListMontadoraTo> CreateListInstance(IEnumerable<Montadora> listMontadora)
        {
            return listMontadora.Select(montadora => new ListMontadoraTo
            {
                MontadoraId = montadora.MontadoraId, Montadora = montadora.Descricao, Destacar = montadora.Destacar
            });
        }
    }
}