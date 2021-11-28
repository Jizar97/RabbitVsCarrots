using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barreira : MonoBehaviour
{
    public void Desativar(){
        StartCoroutine(Espera());
    }

    IEnumerator Espera(){
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
