using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssenceManager : MonoBehaviour
{
    public float EssenceCount;
    public Image EssenceBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddEssence(float EssenceAmount)
    {
        EssenceCount += EssenceAmount;
        EssenceAmount = Mathf.Clamp(EssenceAmount, 0, 50f);

        EssenceBar.fillAmount = EssenceCount / 5f;
    }
}
