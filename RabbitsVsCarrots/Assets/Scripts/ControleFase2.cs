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
    public BossAI bossAI;
    public Desativador barreira;
    public HitSound barreiraSom;
    public Slider slider;
    public Text texto;
    public Desativador avisos;
    public Text textoAvisos;
    public PlayerController Player;
    public HitSound dial;
    public AudioClip bossMusic, vitoria;
    public Desativador npcDesativador;

    private float timeRemaining;
    private const float timeMax = 60f;

    public int fase = 0;

    public int entreiNaRotina = 0;

    void Start(){
        StartCoroutine(Mensagens());
        spawner1.fase = 2;
        spawner2.fase = 2;
        spawner3.fase = 2;
    }

    // Update is called once per frame
    void Update()
    {   

        if(entreiNaRotina == 0){
            slider.value = CalculateSliderValue();

            if(timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
            }
            if(timeRemaining <= 0){
                hacking.fim = false;
                texto.text = ("Pronto!");
                if(hacking.completou == true){
                    StartCoroutine(ReleaseTheKracken());
                    entreiNaRotina++;
                }
            }
        }

        if (boss.currentHealth <= 0 && entreiNaRotina == 1){
            StartCoroutine(Vitoria());
            entreiNaRotina++;
        }
    }

    float CalculateSliderValue(){
        return (timeRemaining / timeMax);
    }

    public void Setup(){
        texto.text = ("");
        timeRemaining = timeMax;
        dial.Toca();
        StartCoroutine(Spawnar());
    }
    
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
        yield return new WaitForSeconds(20);
    
        if(hacking.completou == false) {
            avisos.Reativar();
            textoAvisos.text = "Volte ao terminal!!";
            yield return new WaitForSeconds(3);
            avisos.Desativar();
        }
        
   
    }
    


    IEnumerator Mensagens(){
        yield return new WaitForSeconds(1);
        avisos.Reativar();
        yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(5);
        avisos.Desativar();
    }

    IEnumerator ReleaseTheKracken(){
        yield return new WaitForSeconds(1);
        GetComponent<AudioSource>().Stop();
        barreiraSom.Toca();
        yield return new WaitForSeconds(8);
        barreira.Desativar();
        yield return new WaitForSeconds(1);
        boss.Acordar();
        fase++;
        BossFight();
        avisos.Reativar();
        textoAvisos.text = "MATE A RAINHA!!!";
        yield return new WaitForSeconds(4);
        avisos.Desativar();
    }

    void BossFight(){
        GetComponent<AudioSource> ().clip = bossMusic;
        GetComponent<AudioSource>().PlayOneShot(bossMusic);
        bossAI.VendoOPlayer = true;
    }

    IEnumerator Vitoria(){
        yield return new WaitForSeconds(1);
        GetComponent<AudioSource>().Stop();
        avisos.Reativar();
        textoAvisos.text = "VITORIA!!!";
        GetComponent<AudioSource>().volume = 1.0f;
        GetComponent<AudioSource>().PlayOneShot(vitoria);
        yield return new WaitForSeconds(4);
        avisos.Desativar();
        yield return new WaitForSeconds(2);
        avisos.Reativar();
        npcDesativador.Reativar();
        textoAvisos.text = "FALE COM O RENEGADO!";
    }

}
