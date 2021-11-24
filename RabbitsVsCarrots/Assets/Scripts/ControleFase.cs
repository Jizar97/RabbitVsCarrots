using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int onda, inimigosVivos;
    private bool bloqueia = true;

    // Start is called before the first frame update
    void Start()
    {
        onda = 1;
        StartCoroutine(Espera());
    }

    // Update is called once per frame
    void Update()
    {   
        if(bloqueia == false){
            inimigosVivos = GameObject.FindGameObjectsWithTag("Enemy").Length;
            inimigosVivos = inimigosVivos - 1;

            uiInimCount.SetNum(inimigosVivos);

            //Debug.Log ("Inimigos vivos: " + inimigosVivos);

            if(inimigosVivos == 0){

            if(onda == 5){
                Vitoria();
            } else {
                onda++;
                uiWaveCount.SetNum(onda);
                StartCoroutine(Espera());
                bloqueia = true;
            }
        }
        }
    }

    IEnumerator Espera(){
        Debug.Log ("Esperando....");
        yield return new WaitForSeconds(5);
        spawner1.Spawn(onda);
        spawner2.Spawn(onda);
        spawner3.Spawn(onda);
        spawner4.Spawn(onda);
        bloqueia = false;
    }

    void Vitoria(){
        
    }
}
