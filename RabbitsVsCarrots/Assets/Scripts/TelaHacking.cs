using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaHacking : MonoBehaviour
{

    public Barreira barreira;
    
    public void Setup() {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }
    
    public void Hackear(){
        barreira.Desativar();
    }

    public void Exit(){
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
