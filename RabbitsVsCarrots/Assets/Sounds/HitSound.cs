using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    AudioSource animationSoundPlayer;

    public AudioClip desativando, som2;


    void Start()
    {
        animationSoundPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }



    public void Toca() {
        GetComponent<AudioSource>().PlayOneShot(desativando);
    }

    public void Toca2() {
        GetComponent<AudioSource>().PlayOneShot(som2);
    }
}
