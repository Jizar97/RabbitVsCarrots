using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleFase2 : MonoBehaviour
{


    public TelaHacking hacking;
    public BossHealth boss;
    public Desativador barreira;
    public Slider slider;
    public Text texto;
    public Desativador avisos;
    public Desativador objetivos;
    public Text textoAvisos;

    private float timeRemaining;
    private const float timeMax = 10f;

    int fase = 1;

    void Start(){
        StartCoroutine(Mensagens());
    }

    // Update is called once per frame
    void Update()
    {   

        if(fase == 1){
            slider.value = CalculateSliderValue();

            if(timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
            }
            if(timeRemaining <= 0){
                hacking.fim = false;
                texto.text = ("Pronto!");
                if(hacking.completou == true){
                    barreira.Desativar();
                    boss.Acordar();
                    fase++;
                }
            }
        }

        if(fase == 2){
            
        }
    }

    float CalculateSliderValue(){
        return (timeRemaining / timeMax);
    }

    public void Setup(){
        texto.text = ("");
        timeRemaining = timeMax;
    }

    IEnumerator Mensagens(){
        yield return new WaitForSeconds(5);
        avisos.Reativar();
        yield return new WaitForSeconds(10);
        avisos.Desativar();
    }

}
