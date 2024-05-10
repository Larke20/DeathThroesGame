using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script is for enemy health btw, the player has its own
public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] FloatingHealthBar healthBar;
    private Animator anim;
    Rigidbody2D rb;

    private int MAX_HEALTH = 100;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    private void Start()
    {
        healthBar.UpdateHealthBar(health, MAX_HEALTH);
    }
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage.");
        }
        this.health -= amount;
        healthBar.UpdateHealthBar(health, MAX_HEALTH);
        if(health <= 0)
        {
            playAnimation();
            Invoke(nameof(Dead), 0.5f); 
        }
    }
    public void Heal(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing.");
        }
        bool overMaxHealth = health + amount > MAX_HEALTH;
        if(overMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }
    private void Dead()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
    void playAnimation()
    {
        anim.SetTrigger("isDead");
        Debug.Log("deadanimation");
    }
}
