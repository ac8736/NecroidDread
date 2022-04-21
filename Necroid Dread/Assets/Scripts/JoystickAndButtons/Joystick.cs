using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public int detectionRadius = 300;
    Vector3 originalPosition;
    [HideInInspector]
    public bool movingLeft, movingRight = false;
    [HideInInspector]
    public bool isJumping, isCrouching = false;
    public float joystickDeadZone = 100f;
    // public float minX = -150f, maxX = 150f;
    // public float minY = -150f, maxY = 150f;

    void Start()
    {
        originalPosition = transform.position;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = GetClosestToJoyStick();
            if (touch.phase == TouchPhase.Moved)
            {
                isJumping = false;
                isCrouching = false;
                if (Vector2.Distance(touch.position, transform.position) < detectionRadius)
                {
                    transform.position = touch.position;

                    if (transform.position.x - originalPosition.x > joystickDeadZone)
                    {
                        movingLeft = true;
                        movingRight = false;
                    }
                    else if (transform.position.x - originalPosition.x < -joystickDeadZone)
                    {
                        movingRight = true;
                        movingLeft = false;
                    }

                    if (transform.position.y - originalPosition.y > joystickDeadZone)
                    {
                        isCrouching = false;
                        isJumping = true;
                    }
                    else if (transform.position.y - originalPosition.y < -joystickDeadZone)
                    {
                        isJumping = false;
                        isCrouching = true;
                    }
                }
                else
                {
                    transform.position = originalPosition;
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                transform.position = originalPosition;
                movingLeft = false;
                movingRight = false;
                isJumping = false;
                isCrouching = false;
            }
        }
    }
    Touch GetClosestToJoyStick()
    {
        Touch closest = new Touch();
        float minDist = Mathf.Infinity;
        for (int i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
            if (Vector2.Distance(touch.position, transform.position) < minDist)
            {
                minDist = Vector2.Distance(touch.position, transform.position);
                closest = touch;
            }
        }
        return closest;
    }
}
