using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sucesso : MonoBehaviour
{

    public Text texto;

    // Start is called before the first frame update
    public void Setup(int x)
    {
        if(x == 1){
            texto.text = ("FALHA_");
        } else {
            texto.text = ("SUCESSO_");
        }
        gameObject.SetActive(true);
        StartCoroutine(Espera());
    }

    public void Desativar(){
        gameObject.SetActive(false);
    }

    IEnumerator Espera(){
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
