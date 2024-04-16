using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private Animator anim;
    private GameObject blockArea = default;
    private bool blocking = false;
    private float timeToBlock = 0.25f;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        blockArea = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
        blockArea.SetActive(blocking);
    }

    private void FinishBlock()
    {
        anim.SetBool("block", false);
        anim.SetTrigger("finishBlock");
    }
}
