using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    //TODO: Add a collection system, like a mana bar that increases as the player collects essence
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject); //remove soul essence upon collision
        }
    }

}
