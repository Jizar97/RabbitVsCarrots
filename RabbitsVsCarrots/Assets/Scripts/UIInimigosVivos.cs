using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInimigosVivos : MonoBehaviour
{

    public Text uiNum;

    // Start is called before the first frame update
    void Start()
    {
        uiNum.text = ("Inimigos: 0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNum(int num){
        uiNum.text = ("Inimigos: " + num);
    }
}
