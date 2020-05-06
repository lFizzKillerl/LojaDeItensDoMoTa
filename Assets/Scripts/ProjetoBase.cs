using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetoBase : MonoBehaviour
{
    
    public static float dinheiro = 6000;
    
    int quantidaCaC = 7;
    int quantidaAM = 4;
    int quantidaAD = 8;

    public void ComprarCAC(string name)
    {
        if (quantidaCaC > 0)
        {
            CorpoAC corpoAC = new CorpoAC();
            corpoAC.TrocarValor();
            if (dinheiro < corpoAC.Valor)
            {
                UI.singleton.SemDinheiro();
                return;
            }
            else
            {
                dinheiro -= corpoAC.Valor;
                corpoAC.Nome = name;
                quantidaCaC--;

                UI.singleton.OqEuComprei(name);
            }

        }
        else
        {
            UI.singleton.SemEstoque();
        }
    }

    public void ComprarArmaM(string name)
    {
        if (quantidaAM > 0)
        {
            ArmaMagica armaMagica = new ArmaMagica();
            armaMagica.TrocarValor();
            if (dinheiro < armaMagica.Valor)
            {
                UI.singleton.SemDinheiro();
                return;
            }
            else
            {
                dinheiro -= armaMagica.Valor;
                armaMagica.Nome = name;
                quantidaAM--;

                UI.singleton.OqEuComprei(name);
            }

        }
        else
        {
            UI.singleton.SemEstoque();
        }
    }

    public void ComprarArmaAD(string name)
    {
        if (quantidaAD > 0)
        {
            ArmaAD armaAD = new ArmaAD();
            armaAD.TrocarValor();
            if (dinheiro < armaAD.Valor)
            {
                UI.singleton.SemDinheiro();
                return;
            }
            else
            {
                dinheiro -= armaAD.Valor;
                armaAD.Nome = name;
                quantidaAD--;

                UI.singleton.OqEuComprei(name);
            }

        }
        else
        {
            UI.singleton.SemEstoque();
        }
    }
}

public enum TipoDeArma
{
    CorpoACorpo, ArmaMagica, ArmaADistancia
}

public abstract class Arma
{
    protected TipoDeArma tipodeArma;
    protected string nome;
    protected float valor;
    public abstract void TrocarValor();

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

public class CorpoAC : Arma
{
    public CorpoAC()
    {
        tipodeArma = TipoDeArma.CorpoACorpo;
    }

    public override void TrocarValor()
    {
        Valor = 300;
    }
}

public class ArmaAD : Arma
{
    public ArmaAD()
    {
        tipodeArma = TipoDeArma.ArmaADistancia;
    }

    public override void TrocarValor()
    {
        Valor = 650;
    }
}

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