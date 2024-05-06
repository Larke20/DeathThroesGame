using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    ControllerInput controls; //controller support stuff


    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.5f;
    private float timer = 0f;
    private float cooldownTime = 0.25f; // attack cool down to stop spam
    private float cooldownTimer = 0f; // attack cooldown related
    private float delay = 0.3f; //attack dmg/sync purposes
    void Awake()
    {
        //controller support stuff
        controls = new ControllerInput();
        controls.Gameplay.Attack.performed += contextA => Attack(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Mouse0) && cooldownTimer >= cooldownTime)
        {
            Debug.Log("attack initiated");
            Attack();
            cooldownTimer = 0f;
        }
        if(attacking)
        {
            timer += Time.deltaTime;
            Debug.Log($"attack timer: {timer}");
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }

    }
    private void Attack()
    {
        anim.SetBool("attack", true);
        attacking = true;
        StartCoroutine(SyncDamageWithAttack()); //coroutine to sync dmg applied with attack
    }
    private IEnumerator SyncDamageWithAttack()
    {
        yield return new WaitForSeconds(delay);
        attackArea.SetActive(true);
        
        yield return new WaitForSeconds(timeToAttack - delay);
        attackArea.SetActive(false);
        FinishAttack();
    }
    private void FinishAttack()
    {
        anim.SetBool("attack", false);
        anim.SetTrigger("finishAttack");
    }
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
