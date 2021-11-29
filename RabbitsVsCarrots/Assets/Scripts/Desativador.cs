using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desativador : MonoBehaviour
{
    public void Desativar(){
        gameObject.SetActive(false);
    }

    public void Reativar(){
        gameObject.SetActive(true);
    }
}
