using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaADistancia : Arma
{
    public ArmaADistancia()
    {
        tipodeArma = TipoDeArma.ArmaADistancia;
    }

    public override void TrocarValor()
    {
        Valor = 650;
    }
}
