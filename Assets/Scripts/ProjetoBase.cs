using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetoBase : MonoBehaviour
{
    //criando variavel do valor do dinheiro...
    public static float dinheiro = 6000;
    //criando variaveis da quantidade de itens que estão no "estoque"...
    int quantidaCaC = 7;
    int quantidaAM = 4;
    int quantidaAD = 8;
    //criando função pra comprar algo da categoria de armas corpo a corpo..
    public void ComprarCAC(string name)
    {
        //se quantidade de armas corpo a corpo for maior que 0...
        if (quantidaCaC > 0)
        {
            //criando objeto do tipo corpo a corpo...
            CorpoAC corpoAC = new CorpoAC();
            //trocando o valor do objeto...
            corpoAC.TrocarValor();
            //se dinheiro for menor que o valor...
            if (dinheiro < corpoAC.Valor)
            {
                //chamando a função sem dinheiro...
                UI.singleton.SemDinheiro();
                //terminando/retornando função...
                return;
            }
            //se não... 
            else
            {
                //diminuindo o valor do dinheiro...
                dinheiro -= corpoAC.Valor;
                //trocando nome do objeto...
                corpoAC.Nome = name;
                //diminui 1 da quantidade de armas corpo a corpo...
                quantidaCaC--;
                //chamando a função o que eu comprei...
                UI.singleton.OqEuComprei(name);
            }

        }
        //se não...
        else
        {
            //chamando a função sem estoque...
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
//criando enum para categorizar os itens..
public enum TipoDeArma
{
    //criando as categorias de armas...
    CorpoACorpo, ArmaMagica, ArmaADistancia
}
//criando classe abstrata...
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
//criando classe da categoria de armas corpo a corpo...
public class CorpoAC : Arma
{
    //mostrando tipo da arma (corpo a corpo)...
    public CorpoAC()
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
//criando classe da categoria de armas a distancia...
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
//criando classe da categoria de armas magicas...
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