using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //criando componentes de texto...
    public Text dinheiroT;
    public Text semDinheiro;
    public Text oqEuComprei;
    public Text semEstoque;
    //criando um singleton para ser acessado no script anterior...
    public static UI singleton;
    //criando o void start...
    private void Start()
    {
        //chamando NoDestroy...
        NoDestroy();
        //chamando a função atualizar dinheiro...
        AtualizarDinherio();
    }
    //criando função pra atualizar a quantia de dinheiro que o player possui...
    public void AtualizarDinherio()
    {
        //mostrando a quantia restante de dinheiro do player...
        dinheiroT.text = ProjetoBase.dinheiro.ToString() + "$";
    }
    //criando uma função para dizer que o jogador esta sem diheiro...
    public void SemDinheiro()
    {
        //aparecer texto avisando o player que esta sem dinheiro..
        semDinheiro.enabled = true;
        //chamando a coroutina...
        StartCoroutine(Timer(semDinheiro));
    }
    //criando função pra dizer o que o player comprou...
    public void OqEuComprei(string name)
    {
        //chamando função de atualizar dinheiro...
        AtualizarDinherio();
        //chamando o texto avisando qual item o player comrpou...
        oqEuComprei.enabled = true;
        //dizendo o que deve aparecer no componente texto...
        oqEuComprei.text = "eu comprei " + name;
        //chamando a coroutina...
        StartCoroutine(Timer(oqEuComprei));
    }
    //criando função pra quando o vendedor não possuir produtos suficientes no estoque...
    public void SemEstoque()
    {
        //ativar o componente texto...
        semEstoque.enabled = true;
        //chamando a coroutina...
        StartCoroutine(Timer(semEstoque));
    }
    //criando a coroutina para contar o tempo ate sumir os avisos de texto para o player...
    private IEnumerator Timer(Text texto)
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            texto.enabled = false;
        }
    }
    //transformando UI em um singleton...
    private void NoDestroy()
    {
        //Faz com que o game object que possui esta classe não seja destruído ao trocar de cena
        DontDestroyOnLoad(gameObject);

        if (singleton == null && singleton != this)
        {
            singleton = this;

            //Faz com que o game object que possui esta classe não seja destruído ao trocar de cena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Já existe uma instância dessa classe.");

            Destroy(gameObject);
        }
    }
}
