using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleFase2 : MonoBehaviour
{
    [SerializeField]
    public Spawner spawner1;
    [SerializeField]
    public Spawner spawner2;
    [SerializeField]
    public Spawner spawner3;

    public TelaHacking hacking;
    public BossHealth boss;
    public Desativador barreira;
    public HitSound barreiraSom;
    public Slider slider;
    public Text texto;
    public Desativador avisos;
    public Text textoAvisos;
    public PlayerController Player;

    private float timeRemaining;
    private const float timeMax = 10f;

    int fase = 1;

    void Start(){
        Player.playerLiberado = false;
        StartCoroutine(Mensagens());
        spawner1.fase = 2;
        spawner2.fase = 2;
        spawner3.fase = 2;

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
                    StartCoroutine(ReleaseTheKracken());
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
        //StartCoroutine(Spawnar());
    }
    /*
    IEnumerator Spawnar(){
        yield return new WaitForSeconds(1);
        textoAvisos.text = ("Sobreviva ate que o sistema termine de carregar!!");
        avisos.Reativar();
        spawner1.Spawn(1);
        spawner2.Spawn(1);
        spawner3.Spawn(1);
        yield return new WaitForSeconds(4);
        avisos.Desativar();
        yield return new WaitForSeconds(15);
        spawner1.Spawn(2);
        spawner2.Spawn(2);
        spawner3.Spawn(2);
        yield return new WaitForSeconds(20);
        spawner1.Spawn(2);
        spawner2.Spawn(2);
        spawner3.Spawn(2);
   
    }
    */


    IEnumerator Mensagens(){
        yield return new WaitForSeconds(1);
        avisos.Reativar();
        yield return new WaitForSeconds(3);
        Player.playerLiberado = true;
        yield return new WaitForSeconds(5);
        avisos.Desativar();
    }

    IEnumerator ReleaseTheKracken(){
        yield return new WaitForSeconds(1);
        GetComponent<AudioSource>().Stop();
        barreiraSom.Toca();
        yield return new WaitForSeconds(5);
        barreira.Desativar();
        yield return new WaitForSeconds(1);
        boss.Acordar();
        fase++;
        BossFight();
        /*
        avisos.Reativar();
        yield return new WaitForSeconds(3);
        Player.playerLiberado = true;
        yield return new WaitForSeconds(5);
        avisos.Desativar();
        */
    }

    void BossFight(){

    }

}
