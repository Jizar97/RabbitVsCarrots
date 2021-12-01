using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    int i=0;

    void Start(){
    }

    void Update(){

    }

    public void Spawn(int onda){

        i++;

        for (int j = 1; j <= i; j++){
            GameObject.Instantiate(enemy, transform.position, Quaternion.identity);
        }
        
    }
}
