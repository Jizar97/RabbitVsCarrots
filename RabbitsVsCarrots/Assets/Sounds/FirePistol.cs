using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
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



    public void FirePistolSound() {
        animationSoundPlayer.Play();
        //Instantiate(vfxFire, transform.position, Quaternion.identity);
    }
}
