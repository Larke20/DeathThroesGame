using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public EssenceManager em;
    //TODO: Add a collection system, like a mana bar that increases as the player collects essence
    private void OnTriggerEnter2D(Collider2D essence)
    {
        if(essence.gameObject.CompareTag("SoulEssence"))
        {
            Destroy(essence.gameObject); //remove soul essence upon collision
            em.AddEssence(1);
        }
    }

}
