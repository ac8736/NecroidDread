using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Animator animator;
    
    void Start() {
        StartCoroutine(delay());
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
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
