using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaHacking : MonoBehaviour
{

    public Desativador camera1;
    public Desativador camera2;
    public InputField input;
    public Text pergunta;
    public Sucesso sucesso;
    public Camada camadaUI;
    public Loading loadingUI;
    public PlayerController player;

    string resultado, resultadoEsperado;

    bool passou;

    public bool fim, completou;

    public int i=1, camada=1;
    
    public void Setup() {
        player.podeDisparar = false;
        player.playerLiberado = false;
        gameObject.SetActive(true);
        sucesso.Desativar();
        camadaUI.Setup(camada);
        Cursor.lockState = CursorLockMode.None;
        camera1.Desativar();
        camera2.Desativar();
        Inicio();

    }

    public void Update() {
        resultado = input.text;
    }

    public void Inicio() {

        if(camada == 1){
            if(i == 1){
                Pergunta("7 + 8 = ?", "15");
            } else if(i == 2){
                Pergunta("7 - 4", "3");
            } else {
                Pergunta("8 + 4 - 7 = ?", "5");
            }
        }

        if(camada == 2){
            if(i == 1){
                Pergunta("2 * 8 = ?", "16");
            } else if(i == 2){
                Pergunta("3 * 7 = ?", "21");
            } else {
                Pergunta("27 / 3 = ?", "9");
            }
        }

        if(camada == 3){
            if(i == 1){
                Pergunta("3 * 8 * 2 = ?", "48");
            } else if(i == 2){
                Pergunta("12 + 4 * 2 = ?", "20");
            } else {
                Pergunta("(8 - 6) * 2 = ?", "4");
            }
        }
    }

    public void Pergunta(string eq, string rs){
        pergunta.text = (eq);

        resultadoEsperado = (rs);

        //resultado = input.text;
    }

    public void Ok() {

        if(resultadoEsperado == resultado){
            sucesso.Setup(0);
            i++;
            if(i > 3){
                if(camada == 3){
                    fim = true;
                    completou = true;
                    loadingUI.Setup();
                    Exit();
                } else {
                    camada++;
                    fim = true;
                    camadaUI.Setup(camada);
                i = 1;
                loadingUI.Setup();
                Exit();
                }
            }
            input.text = ("");
            Inicio();
        } else {
            sucesso.Setup(1);
        }
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
        camera1.Reativar();
        camera2.Reativar();
        player.playerLiberado = true;
        player.podeDisparar = true;
    }
    
}
