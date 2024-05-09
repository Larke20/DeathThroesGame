using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int bossHealth = 100;
    public int bossCurrentHealth;
    
    public Animator anim;

    void start()
    {
        bossCurrentHealth = bossHealth;
    }

    public void BossTakeDamage(int amount)
    {
        bossCurrentHealth -= amount;

        if(bossCurrentHealth <= 0)
        {
            anim.SetBool("IsDead", true);
        }
    }
}