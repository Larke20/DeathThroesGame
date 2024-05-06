using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class InteractNextScene : MonoBehaviour
{
    public string sceneName;
    private bool playerInteracted;
    ControllerInput controls;

    void Awake()
    {
        controls = new ControllerInput();
        controls.Gameplay.Interact.performed += contextI => Interact();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && playerInteracted)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    void Interact()
    {
        playerInteracted = true;
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
