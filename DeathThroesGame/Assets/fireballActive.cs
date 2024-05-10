using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballActive : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if(GetComponent<Collider>() != null)
    {
            int damage = 50;
            Health health = GetComponent<Collider>().GetComponent<Health>();
            health.Damage(damage);
    }
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
