using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    AudioSource animationSoundPlayer;

    //SerializeField] private Transform vfxFire;


    void Start()
    {
        animationSoundPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }



    public void Toca() {
        animationSoundPlayer.Play();
        //Instantiate(vfxFire, transform.position, Quaternion.identity);
    }
}
