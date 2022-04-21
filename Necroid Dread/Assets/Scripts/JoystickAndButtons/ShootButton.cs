using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour
{
    public float detectionRadius = 100f;
    void Start()
    {

    }
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
            if (Vector2.Distance(touch.position, transform.position) < detectionRadius)
            {
                print("Shoot Button Pressed");
            }
        }
    }
}
