using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    // Delay variable
    [SerializeField] float delayAmount = 1f;
    // Finish line behaviour
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the gameobject controlled by the player collides with the trigger...
        if (other.tag == "Player")
        {
            // ... reload level 1 at the beginning
            // with using a delay thanks to the Invoke method.
            Invoke("ReloadScene", delayAmount);
        }
    }

    // Reload scene method
    void ReloadScene()
    {
        // Ask Unity's scene manager to load level 1 (indexed as 0).
        SceneManager.LoadScene(0);
    }
}