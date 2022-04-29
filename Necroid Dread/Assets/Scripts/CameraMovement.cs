using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        transform.position = player.position + new Vector3(0, 0, -10);
    }
}
