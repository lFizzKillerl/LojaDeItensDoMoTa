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
            CorpoACorpo corpoAC = new CorpoACorpo();
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
            ArmaADistancia armaAD = new ArmaADistancia();
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