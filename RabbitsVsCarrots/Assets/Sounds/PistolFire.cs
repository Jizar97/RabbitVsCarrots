using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolFire : MonoBehaviour
{

    AudioSource animationSoundPlayer;

    void Start()
    {
        animationSoundPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void PistolFireSound() {
        animationSoundPlayer.Play();
    }
}