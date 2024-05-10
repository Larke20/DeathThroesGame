using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ShootController : MonoBehaviour
{
    // Boolean to track if the player can shoot
    public bool canShoot = false;
    public Transform shootingPoint;
    public GameObject fireball;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (canShoot)
        {
            // Implement your shooting logic here
            Instantiate(fireball, shootingPoint.position, transform.rotation);
            Debug.Log("Player shoots!");
        }
    }

    // Method to update canShoot status
    /**
    public void UpdateCanShoot(bool status)
    {
        canShoot = status;
    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Spellbook"))
        {
            canShoot = true;
        }
    }
}
