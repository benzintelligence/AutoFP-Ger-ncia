﻿using System.ComponentModel;

namespace AutoFP.Gerencia.Domain.ValueObjects.Enums
{
    public enum PecaParalela
    {
        [Description(@"Primeira linha")]
        PrimeiraLinha = 1,

        [Description(@"Segunda linha")]
        SegundaLinha  = 2,

        [Description(@"Terceira linha")]
        TerceiraLinha = 3
    }
}