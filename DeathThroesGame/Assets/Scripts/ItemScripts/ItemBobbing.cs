using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBobbing : MonoBehaviour
{
    public float BobbingSpeed = 1f; //speed of bob motion
    public float BobbingHeight = 0.5f; //max height of bob anim

    private Vector3 StartingPos;
    // Start is called before the first frame update
    void Start()
    {
        StartingPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float VerticalOffset = Mathf.Sin(Time.time * BobbingSpeed) * BobbingHeight; // vert movement based on time

        Vector3 NewPos = StartingPos + new Vector3(0f, VerticalOffset, 0f); // apply calculated offset to Y pos
        transform.position = NewPos;
    }
}
