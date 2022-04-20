using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    // Serialized particle system named as the head crash effect created in hierarchy.
    // In Unity, the head crash effect asset in hierarchy must be manually linked to the script component.
    [SerializeField] ParticleSystem dustTrailEffect;

     // Serialized audio source variable, allowing to select different sound effects for one game object.
    [SerializeField] AudioClip glideSFX;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        // If the player collides with the game object tagged as "ground"...
        if (other.gameObject.tag == "Ground")
        {
            // Play the dust trail particle effect.
            dustTrailEffect.Play();
            // Play the glide sound effect,
            GetComponent<AudioSource>().PlayOneShot(glideSFX);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // If the player doesn't collide with the ground...
        if (other.gameObject.tag == "Ground")
        {
            // Stop playing the dust trail particle effect,
            dustTrailEffect.Stop();
            // Stop playing glide sound effect.
            GetComponent<AudioSource>().Stop();
        }
    }
}