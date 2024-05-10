using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    private Animator anim;
    private GameObject blockArea = default;
    private bool blocking = false;
    private float timeToBlock = 0.25f;
    private float timer = 0f;

    ControllerInput controls; //controller support stuff

    //controller support stuff
    void Awake()
    {
        //controller support stuff
        controls = new ControllerInput();
        controls.Gameplay.Block.performed += contextB => Block(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //blockArea = transform.GetChild(1).gameObject;
        blockArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Block();
        }
        if(blocking)
        {
            timer += Time.deltaTime;
            if(timer >= timeToBlock)
            {
                timer = 0;
                blocking = false;
                blockArea.SetActive(blocking);
            }
        }

    }
    private void Block() 
    {
        anim.SetBool("block", true);
        blocking = true;
        blockArea.SetActive(true);
    }

    private void FinishBlock()
    {
        anim.SetBool("block", false);
        anim.SetTrigger("finishBlock");
        blockArea.SetActive(false);
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
