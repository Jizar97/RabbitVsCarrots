using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    CharacterController controller;
    AudioSource animationSoundPlayer;
    
    private bool groundedPlayer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animationSoundPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }



    private void PlayerFootstepSound() {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer){
            animationSoundPlayer.Play();
        }
    }
}
