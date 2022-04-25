using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engie2_16Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.AddComponent<Engie2_16>();
            Destroy(gameObject);
        }
    }
}
