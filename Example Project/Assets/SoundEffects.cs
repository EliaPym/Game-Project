using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip Land;
    public AudioClip Coin;
    public AudioClip PowerUp;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            audioSource.clip = Land;
        }
        else if (other.gameObject.tag == "Coin")
        {
            audioSource.clip = Coin;
        }
        else if (other.gameObject.tag == "PowerUp")
        {
            audioSource.clip = PowerUp;
        }
        audioSource.Play();
    }
}
