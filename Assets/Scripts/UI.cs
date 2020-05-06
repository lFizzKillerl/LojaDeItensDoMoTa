using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text dinheiroT;
    public Text semDinheiro;
    public Text oqEuComprei;
    public Text semEstoque;

    public static UI singleton;

    private void Start()
    {
        NoDestroy();
        AtualizarDinherio();
    }

    public void AtualizarDinherio()
    {
        dinheiroT.text = ProjetoBase.dinheiro.ToString() + "$";
    }

    public void SemDinheiro()
    {
        semDinheiro.enabled = true;
        StartCoroutine(Timer(semDinheiro));
    }

    public void OqEuComprei(string name)
    {
        AtualizarDinherio();
        oqEuComprei.enabled = true;
        oqEuComprei.text = "eu comprei " + name;
        StartCoroutine(Timer(oqEuComprei));
    }
    public void SemEstoque()
    {
        semEstoque.enabled = true;
        StartCoroutine(Timer(semEstoque));
    }

    private IEnumerator Timer(Text texto)
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            texto.enabled = false;
        }
    }

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
