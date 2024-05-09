using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]private int bossHealth = 100;
    
    private Animator anim;

    void start()
    {
        
    }

    public void BossTakeDamage(int amount)
    {
        this.bossHealth -= amount;

        if(bossHealth <= 0)
        {
            //anim.SetBool("IsDead", true);
            Destroy(gameObject);
            
        }
    }
}