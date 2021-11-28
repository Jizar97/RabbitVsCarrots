using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaHacking : MonoBehaviour
{

    public Barreira barreira;
    public InputField input;
    public Text pergunta;

    string resultado, resultadoEsperado;

    bool passou;

    int i=1;
    
    public void Setup() {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Inicio(i);

    }

    public void Update() {
        resultado = input.text;
    }

    public void Inicio(int x) {
        if(x == 1){
            Pergunta("3 * 8 = ?", "24");
        } else if(x == 2){
            Pergunta("12 + 4 * 2 = ?", "20");
        } else {
            Pergunta("(8 - 6) * 2 = ?", "4");
        }
    }

    public void Pergunta(string eq, string rs){
        pergunta.text = (eq);

        resultadoEsperado = (rs);

        //resultado = input.text;
    }

    public void Ok() {

        if(resultadoEsperado == resultado){
            i++;
            if(i > 3){
                barreira.Desativar();
                Exit();
            }
            Inicio(i);
        }
        /*
        if(passou == true){
            pergunta.text = ("pintao");
            passou = false;
        }
        */
    }
    
    public void Hackear(){
        /*
        pergunta.text = ("pintao");

        if(passou == true){
            barreira.Desativar();
        }
        */
    }

    public void Exit(){
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
