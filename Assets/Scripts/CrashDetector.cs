using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    // Serialized delay amount variable
    [SerializeField] float delayAmount = 0.5f;

    // Serialized particle system named as the head crash effect created in hierarchy.
    // In Unity, the head crash effect asset in hierarchy must be manually linked to the script component.
    [SerializeField] ParticleSystem headCrashEffect;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            // Play the head crash particle effect
            headCrashEffect.Play();
            // And reload level 1 at the beginning
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