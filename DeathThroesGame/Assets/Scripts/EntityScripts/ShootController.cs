using UnityEngine;

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
            Instantiate(fireball, shootingPoint.position, transform.rotation);
        }
    }
    public void Shoot()
    {
        if (canShoot)
        {
            // Implement your shooting logic here
            Debug.Log("Player shoots!");
        }
    }

    // Method to update canShoot status
    public void UpdateCanShoot(bool status)
    {
        canShoot = status;
    }
}
