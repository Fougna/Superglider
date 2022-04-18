using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    // Serialized delay amount variable
    [SerializeField] float delayAmount = 1f;

    // Serialized particle system named as the finish effect created in hierarchy.
    // In Unity, the finish effect asset in hierarchy must be manually linked to the script component.
    [SerializeField] ParticleSystem finishEffect;

    // Finish line behaviour
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the gameobject controlled by the player collides with the trigger...
        if (other.tag == "Player")
        {
            // Play the finish particle effect
            finishEffect.Play();
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