using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackArea : MonoBehaviour
{
    private int bossdamage = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            health.TakeDamage(bossdamage);
        }
    }
}
