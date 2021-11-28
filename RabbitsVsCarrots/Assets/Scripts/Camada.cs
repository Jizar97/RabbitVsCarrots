using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camada : MonoBehaviour
{

    public Text texto;

    // Start is called before the first frame update
    public void Setup(int x)
    {
        texto.text = ("Camada nível 0" + x);
    }
}
