using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    AudioSource animationSoundPlayer;

    public AudioClip desativando;

    //SerializeField] private Transform vfxFire;


    void Start()
    {
        animationSoundPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }



    public void Toca() {
        Debug.Log ("ovo toca essa porra");
        GetComponent<AudioSource>().PlayOneShot(desativando);
    }
}
