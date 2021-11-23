using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //public HealthBarScript healthBar;

    void Start(){
        currentHealth = maxHealth;
    }

    void Update(){
        if(currentHealth <= 0){
            Destroy(gameObject);
            //destroiObj();
        }
    }
/*
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<BulletControler>() != null){
            Debug.Log ("Levou dano");
        } else {
            //Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        //Destroy(gameObject);
    }
    */
    void OnCollisionEnter(Collision collision){

        if(collision.gameObject.name == "Bullet2(Clone)"){
            TakeDamage(20);
        }
    }
    

    public void TakeDamage(int damage){
        currentHealth -= damage;
    }

    private void destroiObj(){
        
    }
}
