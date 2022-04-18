using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    // Delay variable
    [SerializeField] float delayAmount = 0.5f;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
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