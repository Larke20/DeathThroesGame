using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChange : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Door"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
