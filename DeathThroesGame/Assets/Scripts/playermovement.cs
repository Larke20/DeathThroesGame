
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 moveInput;
    [SerializeField]private float speed;

    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    //start of this attack stuff
    private void Attack(){

        anim.SetBool("attack", true);

    }
    public void FinishAttack()
    {
        anim.SetBool("attack", false);
        anim.SetTrigger("finishAttack");
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
        }
        else if(moveInput.x < -0.01f){
            transform.localScale = new Vector3(-0.18f,0.20f,1);
        }
        //attack activation
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        //animation
        bool isMoving = moveInput.magnitude > 0.01f;
        anim.SetBool("run", isMoving);
        
    }
}
