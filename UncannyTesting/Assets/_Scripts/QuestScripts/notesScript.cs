﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notesScript : MonoBehaviour
{

    private bool inTrigger = false;

    private bool keysEnabled;

    public GameObject dialogueBox;

    public GameObject observeInteract;

    public GameObject scene;

    public Dialogue highVolumeInteractDialogue;

    public Dialogue highVolumeObserveDialogue;

    public Dialogue lowVolumeInteractDialogue;

    public Dialogue lowVolumeObserveDialogue;

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
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(lowVolumeInteractDialogue);
                narrativeManager.puzzleStart = true;
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(lowVolumeObserveDialogue);
                narrativeManager.puzzleStart = true;
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
            Time.timeScale = 0;
            TriggerDialogue();
        }

        if (inTrigger == true && Input.GetKeyDown(KeyCode.E) && keysEnabled == true)
        {
            ///StartCoroutine(interactActivate());
            ///Debug.Log("You are interacting with the Jeffko object");
            observe = false;
            keysEnabled = false;
            observeInteract.SetActive(false);
            dialogueBox.SetActive(true);
            Time.timeScale = 0;
            TriggerDialogue();

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
