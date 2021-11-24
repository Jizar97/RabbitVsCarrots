using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public void Setup() {
        gameObject.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("Playground");
    }

    public void Exit(){

    }
}
