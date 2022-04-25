using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(3, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        print("equipped");
    }
}
