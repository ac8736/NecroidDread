using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Float());
    }

    IEnumerator Float() {
        while (true) {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);

            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
