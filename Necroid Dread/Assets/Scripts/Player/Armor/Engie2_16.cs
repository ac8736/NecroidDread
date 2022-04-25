using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engie2_16 : MonoBehaviour
{
    public GameObject head;
    public Sprite headSprite;
    void Start()
    {
        head = GameObject.Find("Head");
        headSprite = GetComponent<ArmorSprites>().headArmorSprites[1];
        head.GetComponent<SpriteRenderer>().sprite = headSprite;
    }
}
