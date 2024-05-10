using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth; 
    public HealthBar healthBar;
    public GameManagerScript gameManager;
    private bool isDead;
    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    public void Update()
    {
        
            
            if(currentHealth <= 0 && !isDead)
            {
                isDead = true;
                gameObject.SetActive(false);
                gameManager.gameOver();
            }
        
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    
}
