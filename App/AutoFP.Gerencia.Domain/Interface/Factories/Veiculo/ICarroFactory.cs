﻿using AutoFP.Gerencia.Domain.Entities.Veiculo;

namespace AutoFP.Gerencia.Domain.Interface.Factories.Veiculo
{
    public interface ICarroFactory
    {
        Carro CreateInstance();
    }
}