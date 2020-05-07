using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpoACorpo : Arma
{
    //mostrando tipo da arma (corpo a corpo)...
    public CorpoACorpo()
    {
        tipodeArma = TipoDeArma.CorpoACorpo;
    }
    //sobrescrevendo a função de trocar o valor...
    public override void TrocarValor()
    {
        //trocando um valor a arma...
        Valor = 300;
    }
}