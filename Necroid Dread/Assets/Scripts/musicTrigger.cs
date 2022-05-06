using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicTrigger : MonoBehaviour
{
    public AudioSource _audio;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !_audio.isPlaying)
        {
            _audio.Play();
        }
    }
}
