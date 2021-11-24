using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    public Text textbox;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Espera());
        textbox.text = ("BEM VINDO AO TUTORIAL DE RABBIT'S VS. CARROT'S");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Espera(){
        yield return new WaitForSeconds(20);
        Debug.Log ("Esperei");
    }
}
