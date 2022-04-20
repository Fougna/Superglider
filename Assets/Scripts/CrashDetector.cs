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

    // Serialized audio source variable, allowing to select different sound effects for one game object.
    [SerializeField] AudioClip crashSFX;

    // Crash state boolean variable set to default to false. 
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player hits the ground on its trigger collider (head) and hasn't crashed already...
        if (other.tag == "Ground" && !hasCrashed)
        {
            // The player's crash state equals to true and therefore, the rest of the condition can be executed.
            hasCrashed = true;
            // Find the player controller and disable it,
            FindObjectOfType<SupergliderController>().DisableControls();
            // Play the head crash particle effect,
            headCrashEffect.Play();
            // Play the crash sound effect only once,
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            // And reload level 1 at the beginning, using a delay thanks to the Invoke method.
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