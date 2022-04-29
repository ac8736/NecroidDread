using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDetection : MonoBehaviour
{
    public bool shoot;
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i) {
            if (Input.GetTouch(i).phase == TouchPhase.Began) {    
                if (Vector2.Distance(Input.GetTouch(i).position, transform.position) < 50) {
                    shoot = true;
                }
            }
            if (Input.GetTouch(i).phase == TouchPhase.Ended) {
                shoot = false;
            }
        }
    }
}
