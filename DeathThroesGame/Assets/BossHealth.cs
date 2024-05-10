using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]private int bossHealth = 100;
    public float destroyDelay = 2f;
    
    
    private Animator anim;
    public GameManagerScript gameManager;
    private bool bossIsDead;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void BossTakeDamage(int amount)
    {
        this.bossHealth -= amount;

        if(bossHealth <= 0 && !bossIsDead)
        {
            
            bossIsDead = true;
            anim.SetBool("IsDead", true);
            StartCoroutine(DestroyAfterDelay());
            
            gameManager.gameWin();
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