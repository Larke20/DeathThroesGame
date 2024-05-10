using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    private int eyedamage = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position; // track to player pos
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(-direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        timer += Time.deltaTime;
        if(timer > 1)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            health.TakeDamage(eyedamage);
            Destroy(gameObject);
        }
    }
}
