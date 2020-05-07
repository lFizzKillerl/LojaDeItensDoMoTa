using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaMagica : Arma
{
    public ArmaMagica()
    {
        tipodeArma = TipoDeArma.ArmaMagica;
    }

    public override void TrocarValor()
    {
        Valor = 700;
    }
}