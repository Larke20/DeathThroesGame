using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public EssenceManager em;
    public ShootController shootController; // Reference to the ShootController script
    //TODO: Add a collection system, like a mana bar that increases as the player collects essence
    private void OnTriggerEnter2D(Collider2D collectable)
    {
        if(collectable.gameObject.CompareTag("SoulEssence"))
        {
            Destroy(collectable.gameObject); //remove soul essence upon collision
            em.AddEssence(1);
        }
        /**
        if (collectable.gameObject.CompareTag("Spellbook"))
        {
            // Update canShoot variable in ShootController to true
            Destroy(collectable.gameObject);

            if (shootController != null)
            {
                shootController.UpdateCanShoot(true);
            }

        }
        */
    }

}
