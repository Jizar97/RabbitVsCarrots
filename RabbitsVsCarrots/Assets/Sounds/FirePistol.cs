using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{

    AudioSource animationSoundPlayer;


    void Start()
    {
        animationSoundPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }



    public void FirePistolSound() {
        animationSoundPlayer.Play();
    }
}
