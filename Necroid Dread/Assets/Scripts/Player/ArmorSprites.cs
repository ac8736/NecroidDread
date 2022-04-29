using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSprites : MonoBehaviour
{
    public Sprite[] armorSprites;

    void Awake() {
        DontDestroyOnLoad(this);
    }
}
