using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timmyScript : MonoBehaviour
{

    private bool inTrigger = false;

    private bool keysEnabled;

    public GameObject dialogueBox;

    public GameObject scene;

    public Dialogue beforeSpraypaintDialogue;

    public Dialogue afterSpraypaintDialogue;

    public Dialogue observeDialogue;

    public bool observe = false;

    public narrativeManager narrativeManager;

    public int final = 0;

    // Use this for initialization
    void Start()
    {
        keysEnabled = true;
        dialogueBox.SetActive(false);
    }

    public void TriggerDialogue()
    {
        if (observe == false)
        {
            if (narrativeManager.SpraypaintReceived)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(afterSpraypaintDialogue);
            }
            else
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeSpraypaintDialogue);
                narrativeManager.SpraypaintReceived = true;
            }
        }

        if (observe == true)
        {
            FindObjectOfType<dialogueManager>().StartDialogue(observeDialogue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger == true && Input.GetKeyDown(KeyCode.Q) && keysEnabled == true)
        {
            ///StartCoroutine(observeActivate());
            ///Debug.Log("You are observing the Jeffko object");
            observe = true;
            keysEnabled = false;
            dialogueBox.SetActive(true);
            TriggerDialogue();
            Time.timeScale = 0;
        }

        if (inTrigger == true && Input.GetKeyDown(KeyCode.E) && keysEnabled == true)
        {
            ///StartCoroutine(interactActivate());
            ///Debug.Log("You are interacting with the Jeffko object");
            observe = false;
            keysEnabled = false;
            dialogueBox.SetActive(true);
            TriggerDialogue();
            Time.timeScale = 0;

        }

        if (Time.timeScale == 1)
        {
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