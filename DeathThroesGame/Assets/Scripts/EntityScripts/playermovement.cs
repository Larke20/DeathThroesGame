
using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour
{
    //movement related 
    private Rigidbody2D body;
    private Vector2 moveInput;
    [SerializeField]private float speed;
    //animator related 
    private Animator anim;

    private bool isDashing = false;
    private float dashSpeed = 4f;
    private float dashDuration = .1f;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    //end of this attack stuff
    private void Update()
    {
        //l,r,u,d movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        body.velocity = moveInput * speed;

        //l,r flip
        if(moveInput.x > 0.01f){
            transform.localScale = new Vector3(0.18f, 0.20f, 1);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(moveInput.x < -0.01f){
            //transform.localScale = new Vector3(-0.18f,0.20f,1);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //animation
        bool isMoving = moveInput.magnitude > 0.01f;
        anim.SetBool("run", isMoving);

        //input for dash will be LShift for now
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        transform.position += movement * (isDashing ? dashSpeed : speed) * Time.deltaTime;




        
    }
    IEnumerator Dash()
    {
        isDashing = true;
        float originalSpeed = speed;
        speed = dashSpeed; // Increase speed during dash
        yield return new WaitForSeconds(dashDuration);
        speed = originalSpeed; // Reset speed to normal
        isDashing = false;
    }
}
