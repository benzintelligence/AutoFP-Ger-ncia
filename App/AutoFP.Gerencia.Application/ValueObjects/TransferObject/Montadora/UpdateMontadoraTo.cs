﻿namespace AutoFP.Gerencia.Application.ValueObjects.TransferObject.Montadora
{
    public class UpdateMontadoraTo
    {
        public int MontadoraId { get; set; }

        public string Montadora { get; set; }

        public bool Destacar { get; set; }
    }
}