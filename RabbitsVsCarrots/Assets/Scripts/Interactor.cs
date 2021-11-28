using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{

    private IInteractable currentInteractable = null;

    void Update()
    {
        CheckForInteraction();
    }

    private void CheckForInteraction(){
        //Debug.Log ("Cheguei aqui e to testando");
        if(currentInteractable == null) { return; }

        Debug.Log ("Cheguei aqui e to testando");
        
        if(Input.GetKeyDown(KeyCode.E)){
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter(Collider other){
        var interactable = other.GetComponent<IInteractable>();

        if(interactable == null) { return; }

        currentInteractable = interactable;
    }

    private void OnTriggerExit(Collider other){
        var interactable = other.GetComponent<IInteractable>();

        if(interactable == null) { return; }

        if(interactable != currentInteractable) { return; }

        currentInteractable = null;
    }
}
