using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    private bool keysEnabled;

    public GameObject dialogueBox;

    private bool inTrigger = false;

    void Start()
    {
        keysEnabled = true;
        dialogueBox.SetActive(false);
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }

    private void Update()
    {
        if (inTrigger == true && Input.GetKeyDown(KeyCode.Q) && keysEnabled == true)
        {
            ///StartCoroutine(observeActivate());
            ///Debug.Log("You are observing the Jeffko object");
            keysEnabled = false;
            dialogueBox.SetActive(true);
            TriggerDialogue();
            Time.timeScale = 0;
        }

        if (inTrigger == true && Input.GetKeyDown(KeyCode.E) && keysEnabled == true)
        {
            ///StartCoroutine(interactActivate());
            ///Debug.Log("You are interacting with the Jeffko object");
            keysEnabled = false;
            TriggerDialogue();
            Time.timeScale = 0;

        }

        if ((Time.timeScale == 0) && Input.GetKeyDown(KeyCode.Space) && keysEnabled == false)
        {
            Time.timeScale = 1;
            dialogueBox.SetActive(false);
            keysEnabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("inTrigger is true");
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("inTrigger is false");
            inTrigger = false;
        }
    }

}
