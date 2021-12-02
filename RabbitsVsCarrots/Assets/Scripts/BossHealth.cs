using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 2000;
    public int currentHealth;

    public BossAI bossAI;
    public ToggleUI toggle;
    public Desativador barraVida;
    public HealthBarScript barraVida2;

    void Start(){
        currentHealth = maxHealth;
        barraVida2.SetMaxHealth(maxHealth);
    }

    void Update(){
        if(currentHealth <= 0){
            //enemyAI.Morrer();
            bossAI.VendoOPlayer = false;
            bossAI.Morrer();
            StartCoroutine(Destroi());
            //destroiObj();
        }
    }

    void OnCollisionEnter(Collision collision){

        if(collision.gameObject.name == "Bullet2(Clone)"){
            TakeDamage(35);
            barraVida2.SetHealth(currentHealth);
            toggle.HitMarker();
        }
    }
    

    public void TakeDamage(int damage){
        currentHealth -= damage;
    }

    public void Acordar(){
        barraVida.Reativar();
    }

    IEnumerator Destroi(){
        yield return new WaitForSeconds(40);
        //Destroy(gameObject);
    }
}
