using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    private int i = 1;
    public int fase=1;

    void Start(){
    }

    void Update(){

    }

    public void Spawn(int onda){
        if(fase == 1){
            if(onda > 2){
                i++;
            }
            Debug.Log ("i eh igual a "+ i);
            for (int j = 1; j <= i; j++){
                GameObject.Instantiate(enemy, transform.position, Quaternion.identity);
                
            }

        } else {

            for (int j = 1; j <= onda; j++){
                GameObject.Instantiate(enemy, transform.position, Quaternion.identity);
            }

        }
        
    }
}
