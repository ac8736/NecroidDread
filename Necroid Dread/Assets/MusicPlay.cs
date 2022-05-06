using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    public GameObject music;
    void Start()
    {
        music = GameObject.FindWithTag("Music");
        music.GetComponent<Music>().PlayMusic();
    }
}
