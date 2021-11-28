using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    
    [SerializeField] private string interactionText = "Hello";


    public void Interact(){
        Debug.Log(interactionText);
    }


}
