using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

    public ControleFase2 controlador;
    public TelaHacking hacking;
    public Desativador barreira;
    public Text texto;


    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        cam = Camera.main;

    }

    public void Setup(){
        gameObject.SetActive(true);
        controlador.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.transform.rotation;
        /*
        if(hacking.completou == true && texto.text == "Pronto!"){
            barreira.Desativar();
        }
        */
    }
}
