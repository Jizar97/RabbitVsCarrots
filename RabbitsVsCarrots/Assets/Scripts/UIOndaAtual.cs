using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOndaAtual : MonoBehaviour
{

    public Text uiNum;

    // Start is called before the first frame update
    void Start()
    {
        uiNum.text = ("Onda: 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNum(int num){
        uiNum.text = ("Onda: " + num);
    }
}
