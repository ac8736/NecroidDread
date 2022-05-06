using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public Transform[] spawnSpots;
    public GameObject ad;
    bool playerNear = false;
    public int detection = 10;
    void Start()
    {
        StartCoroutine(spawn());
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y) < 15)
        {
            if (Mathf.Abs(transform.position.y - GameObject.FindGameObjectWithTag("Player").transform.position.y) < 50)
            {
                playerNear = true;
            }
            else
            {
                playerNear = false;
            }
        }
        else
        {
            playerNear = false;
        }
    }
    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (playerNear)
            {
                for (int i = 0; i < spawnSpots.Length; i++)
                {
                    Instantiate(ad, spawnSpots[i].position, spawnSpots[i].rotation);
                }
            }
        }
    }
}
