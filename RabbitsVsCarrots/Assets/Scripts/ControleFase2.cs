using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFase2 : MonoBehaviour
{


    public TelaHacking hacking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (hacking.fim == true){
            StartCoroutine(Espera());
        }
    }

    IEnumerator Espera(){
        yield return new WaitForSeconds(5);
        hacking.fim = false;
    }

}
