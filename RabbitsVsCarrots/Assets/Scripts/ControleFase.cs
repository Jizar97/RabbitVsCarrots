using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFase : MonoBehaviour
{


    [SerializeField]
    public Spawner spawner;
    [SerializeField]
    public UIInimigosVivos uiInimCount;
    [SerializeField]
    public UIOndaAtual uiWaveCount;

    private int onda, inimigosVivos;

    // Start is called before the first frame update
    void Start()
    {
        onda = 1;
    }

    // Update is called once per frame
    void Update()
    {
        inimigosVivos = GameObject.FindGameObjectsWithTag("Enemy").Length;
        inimigosVivos = inimigosVivos - 1;

        uiInimCount.SetNum(inimigosVivos);

        //Debug.Log ("Inimigos vivos: " + inimigosVivos);

        if(inimigosVivos == 0){
            if(onda == 5){

            } else {
                onda += 1;
                uiWaveCount.SetNum(onda);
                spawner.Spawn(onda);
            }
        }
    }
}
