﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ryanScript : MonoBehaviour {

    private bool inTrigger = false;

    private bool keysEnabled;

    public GameObject dialogueBox;

    public GameObject observeInteract;

    public GameObject scene;

    public Dialogue beforeVolumeInteractDialogue;

    public Dialogue beforeVolumeObserveDialogue;

    public Dialogue beforeJulietInteractDialogue;

    public Dialogue beforeJulietObserveDialogue;

    public Dialogue beforeCodeInteractDialogue;

    public Dialogue beforeCodeObserveDialogue;

    public Dialogue afterCodeInteractDialogue;

    public Dialogue afterCodeObserveDialogue;

    public bool observe = false;

    public narrativeManager narrativeManager;

    public int final = 0;

    // Use this for initialization
    void Start()
    {
        keysEnabled = true;
        dialogueBox.SetActive(false);
        observeInteract.SetActive(false);
    }

    public void TriggerDialogue()
    {
        if (narrativeManager.RyanTalkedTo)
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(afterCodeInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(afterCodeObserveDialogue);
            }
        }
        else if (narrativeManager.VolumeDown && narrativeManager.JulietTalkedTo)
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeCodeInteractDialogue);
                narrativeManager.RyanTalkedTo = true;
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeCodeObserveDialogue);
            }
        }
        else if (narrativeManager.VolumeDown && narrativeManager.JulietTalkedTo != true)
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeJulietInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeJulietObserveDialogue);
            }
        }
        else
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeVolumeInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeVolumeObserveDialogue);
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
