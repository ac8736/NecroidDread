using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Animator animator;
    public bool inDialogue = false;
    public Transform player;
    bool appeared = false;
    
    private void Update() {
        if (Vector3.Distance(transform.position, player.position) < 10 && !inDialogue && !appeared) {
            inDialogue = true;
            StartCoroutine(delay());
            appeared = true;
        }
        if (inDialogue) {
            for (int i = 0; i < Input.touchCount; ++i) {
                if (Input.GetTouch(i).phase == TouchPhase.Began) {
                    print("began");
                    FindObjectOfType<DialogueManager>().DisplayNextSentence();
                }
            }
        }
    }
    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    IEnumerator delay() {
        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Open");
        TriggerDialogue();
    }
}
