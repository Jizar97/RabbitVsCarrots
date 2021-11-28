using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaHacking : MonoBehaviour
{

    public Barreira barreira;
    public InputField input;
    public Text pergunta;

    string resultado;

    bool passou;
    
    public void Setup() {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Inicio();

    }

    public void Update() {
        
    }

    public void Inicio() {

        pergunta.text = ("8 * 3 = ?");

        while (resultado != "24")
        {
            resultado = input.text;
        }

        pergunta.text = ("8 * 3 = ?");

        if(resultado == "24"){
            passou = true;
        } else {

        }

        pergunta.text = ("12 + 4 * 2 = ?");

        if(resultado == "20"){
            passou = true;
        } else {

        }

        pergunta.text = ("(3 - 5) * 2 = ?");

        if(resultado == "4"){
            passou = true;
        } else {

        }
    }
    
    public void Hackear(){

        if(passou == true){
            barreira.Desativar();
        }
    }

    public void Exit(){
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
