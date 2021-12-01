using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    AudioSource animationSoundPlayer;

    public AudioClip desativando;


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
}
