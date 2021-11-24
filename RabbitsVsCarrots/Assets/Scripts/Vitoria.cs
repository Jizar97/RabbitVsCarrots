using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Vitoria : MonoBehaviour
{
    
    AudioSource animationSoundPlayer;

    public void Setup() {
        gameObject.SetActive(true);
        animationSoundPlayer = GetComponent<AudioSource>();
        animationSoundPlayer.Play();
    }

    public void Restart(){
        SceneManager.LoadScene("Playground");
    }

    public void Exit(){
        SceneManager.LoadScene("MainMenu");
    }
}
