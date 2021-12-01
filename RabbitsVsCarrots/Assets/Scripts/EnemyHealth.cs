using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public EnemyAI enemyAI;
    public ToggleUI toggle;

    [SerializeField] private Transform vfxHit;

    void Start(){
        currentHealth = maxHealth;
    }

    void Update(){
        if(currentHealth <= 0){
            enemyAI.Morrer();
            StartCoroutine(Destroi());
            //destroiObj();
        }
    }

    void OnCollisionEnter(Collision collision){

        if(collision.gameObject.name == "Bullet2(Clone)"){
            TakeDamage(35);
            toggle.HitMarker();
            //Instantiate(vfxHit, transform.position, Quaternion.identity);
        }
    }
    

    public void TakeDamage(int damage){
        currentHealth -= damage;
    }

    private void destroiObj(){
        
    }

    IEnumerator Destroi(){
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
