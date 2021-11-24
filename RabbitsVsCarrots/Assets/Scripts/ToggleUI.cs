using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUI : MonoBehaviour
{

    public Toggle toggle;
    public HitSound hitSound;

    // Start is called before the first frame update
    void Start()
    {
        toggle.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitMarker(){
        toggle.interactable = true;
        hitSound.Toca();
        toggle.interactable = false;
    }

}
