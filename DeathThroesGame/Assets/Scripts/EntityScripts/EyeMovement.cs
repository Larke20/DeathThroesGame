using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float detectionRange = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            target = player.GetComponent<Transform>();
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            float distance = Vector2.Distance(transform.position, target.position);
            if (distance <= detectionRange)
            {
                //direction vector towards the player
                Vector2 direction = (target.position - transform.position).normalized;

                //eye track toward the player
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                //angle in degrees from the direction vector
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                //angle limit so eye doesnt flip around and turn into a spastic
                if (angle > 30)
                {
                    angle = 30;
                }
                else if (angle < -30)
                {
                    angle = -30;
                }

                //set rotation of eye to face direction of travel
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
}
