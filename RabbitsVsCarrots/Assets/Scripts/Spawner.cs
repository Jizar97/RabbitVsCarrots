using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    int i=1;

    void Start(){
    }

    void Update(){

    }

    public void Spawn(int onda){
        if(onda < 3 && onda > 1){
            i++;
        } else {
            i += 2;
        }
        
        for (int j = 1; j <= i; j++){
            GameObject.Instantiate(enemy, transform.position, Quaternion.identity);
        }
        
    }
}
