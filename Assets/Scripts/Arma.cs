using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma
{
    //criando variaveis para mudar as informações...
    protected TipoDeArma tipodeArma;
    protected string nome;
    protected float valor;
    //trocando valor do objeto...
    public abstract void TrocarValor();
    //construtor do nome e do valor...
    public string Nome
    {
        get
        {
            return nome;
        }
        set
        {
            nome = value;
        }
    }

    public float Valor
    {
        get
        {
            return valor;
        }
        set
        {
            valor = value;
        }
    }
}
