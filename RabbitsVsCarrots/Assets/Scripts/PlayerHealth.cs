using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarScript healthBar;
    public GameOver gameOverScreen;
    public Animator animator;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update(){
        if(currentHealth <= 0){
            GetComponent<Animator>().SetBool ("Morreu", true);
            StartCoroutine(gameOver());
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator gameOver(){
        //Destroy(gameObject);
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(3);
        gameOverScreen.Setup();
    }
}
