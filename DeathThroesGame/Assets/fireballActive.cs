using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballActive : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float timer;
    private int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;   
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
        if(collider.GetComponent<BossHealth>() != null)
        {
            BossHealth bossHealth = collider.GetComponent<BossHealth>();
            bossHealth.BossTakeDamage(damage);
        }

    }
    


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > .5)
        {
            Destroy(gameObject);
        }
    }
}
