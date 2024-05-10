using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]private int bossHealth = 100;
    public float destroyDelay = 2f;
    
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void BossTakeDamage(int amount)
    {
        this.bossHealth -= amount;

        if(bossHealth <= 0)
        {
            anim.SetBool("IsDead", true);
            StartCoroutine(DestroyAfterDelay());
            //Destroy(gameObject);
            
        }
    }
    IEnumerator DestroyAfterDelay()
    {
        // Wait for the specified delay before destroying the GameObject
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the GameObject
        Destroy(gameObject);
    }
}