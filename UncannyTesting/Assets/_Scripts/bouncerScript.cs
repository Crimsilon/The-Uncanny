using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncerScript : MonoBehaviour {

    private bool inTrigger = false;

    private bool keysEnabled;

    public GameObject dialogueBox;

    public GameObject observeInteract;

    public GameObject scene;

    public Dialogue beforeTalkedInteractDialogue;

    public Dialogue beforeTalkedObserveDialogue;

    public Dialogue beforeBabeInteractDialogue;

    public Dialogue beforeBabeObserveDialogue;

    public Dialogue afterBabeInteractDialogue;

    public Dialogue afterBabeObserveDialogue;

    public bool observe = false;

    public narrativeManager narrativeManager;

    // Use this for initialization
    void Start()
    {
        keysEnabled = true;
        dialogueBox.SetActive(false);
        observeInteract.SetActive(false);
    }

    public void TriggerDialogue()
    {
        if (narrativeManager.BouncerTalkedTo && narrativeManager.BabeFound)
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(afterBabeInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(afterBabeObserveDialogue);
            }
        }
        else if (narrativeManager.BouncerTalkedTo && narrativeManager.BabeFound != true)
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeBabeInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeBabeObserveDialogue);
            }
        }
        else
        {
            if (observe == false)
            {
                narrativeManager.BouncerTalkedTo = true;
                FindObjectOfType<dialogueManager>().StartDialogue(beforeTalkedInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeTalkedObserveDialogue);
            }
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
            observeInteract.SetActive(false);
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
            observeInteract.SetActive(false);
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
            observeInteract.SetActive(true);
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("inTrigger is false");
            observeInteract.SetActive(false);
            inTrigger = false;
        }
    }
}
