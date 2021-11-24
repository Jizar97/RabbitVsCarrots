using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarScript healthBar;
    public GameOver gameOverScreen;

    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update(){
        if(currentHealth <= 0){
            Debug.Log ("Morri");
            gameOver();
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void gameOver(){
        Destroy(gameObject);
        Cursor.lockState = CursorLockMode.None;
        gameOverScreen.Setup();
    }
}
