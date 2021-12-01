using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleFase : MonoBehaviour
{


    [SerializeField]
    public Spawner spawner1;
    [SerializeField]
    public Spawner spawner2;
    [SerializeField]
    public Spawner spawner3;
    [SerializeField]
    public Spawner spawner4;

    [SerializeField]
    public UIInimigosVivos uiInimCount;
    [SerializeField]
    public UIOndaAtual uiWaveCount;

    public AudioClip batalha, vitoria;

    public Desativador mostrarTexto;
    public Desativador barraDeVida;
    public Desativador inimigosUI;
    public Desativador npcDesativador;
    public NPC npc;
    public Text texto;

    private int onda, inimigosVivos;
    private bool bloqueia = true, fim = false;

    // Start is called before the first frame update
    void Start()
    {
        onda = 1;
        StartCoroutine(Onda1());
        GetComponent<AudioSource> ().clip = batalha;
    }

    // Update is called once per frame
    void Update()
    {   
        if(fim == false && bloqueia == false){
            inimigosVivos = GameObject.FindGameObjectsWithTag("Enemy").Length;
            inimigosVivos = inimigosVivos - 1;

            uiInimCount.SetNum(inimigosVivos);

            //Debug.Log ("Inimigos vivos: " + inimigosVivos);

            if(inimigosVivos == 0){

                if(onda == 5){
                    StartCoroutine(Vitoria());
                } else {
                    onda++;
                    uiWaveCount.SetNum(onda);
                    barraDeVida.Desativar();
                    inimigosUI.Desativar();
                    StartCoroutine(OndaX());
                    bloqueia = true;
                }
            }
        }
        if(npc.falou == true){
            mostrarTexto.Desativar();
        }
    }

    IEnumerator Onda1(){
        yield return new WaitForSeconds(5);
        mostrarTexto.Reativar();
        yield return new WaitForSeconds(10);
        mostrarTexto.Desativar();
        yield return new WaitForSeconds(2);
        mostrarTexto.Reativar();
        texto.text = "3";
        yield return new WaitForSeconds(1);
        texto.text = "2";
        yield return new WaitForSeconds(1);
        texto.text = "1";
        yield return new WaitForSeconds(1);
        texto.text = "AGORA!!";
        yield return new WaitForSeconds(1);
        mostrarTexto.Desativar();
        barraDeVida.Reativar();
        inimigosUI.Reativar();
        spawner1.Spawn(onda);
        spawner2.Spawn(onda);
        spawner3.Spawn(onda);
        spawner4.Spawn(onda);
        bloqueia = false;
    }

    IEnumerator OndaX(){
        yield return new WaitForSeconds(1);
        mostrarTexto.Reativar();
        texto.text = "SOBREVIVEU A ONDA: " + (onda - 1);
        yield return new WaitForSeconds(2);
        mostrarTexto.Desativar();
        yield return new WaitForSeconds(1);
        mostrarTexto.Reativar();
        texto.text = "PREPARE-SE PARA A PROXIMA ONDA";
        yield return new WaitForSeconds(3);
        mostrarTexto.Desativar();
        yield return new WaitForSeconds(2);
        mostrarTexto.Reativar();
        texto.text = "3";
        yield return new WaitForSeconds(1);
        texto.text = "2";
        yield return new WaitForSeconds(1);
        texto.text = "1";
        yield return new WaitForSeconds(1);
        texto.text = "AGORA!!";
        yield return new WaitForSeconds(1);
        mostrarTexto.Desativar();
        barraDeVida.Reativar();
        inimigosUI.Reativar();
        spawner1.Spawn(onda);
        spawner2.Spawn(onda);
        spawner3.Spawn(onda);
        spawner4.Spawn(onda);
        bloqueia = false;

    }

    IEnumerator Vitoria(){
        yield return new WaitForSeconds(1);
        barraDeVida.Desativar();
        inimigosUI.Desativar();
        mostrarTexto.Reativar();
        texto.text = "VITORIA!!!";
        VictorySound();
        yield return new WaitForSeconds(3);
        mostrarTexto.Desativar();
        yield return new WaitForSeconds(3);
        mostrarTexto.Reativar();
        npcDesativador.Reativar();
        texto.text = "FALE COM O RENEGADO!";
    }

    private void VictorySound(){
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().volume = 1.0f;
        GetComponent<AudioSource> ().PlayOneShot(vitoria);
        fim = true;
    }
}
