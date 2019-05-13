using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    private bool inTrigger = false;

    private bool keysEnabled;

    public GameObject dialogueBox;

    public GameObject observeInteract;

    public GameObject scene;

    public Dialogue beforeSpraypaintInteractDialogue;

    public Dialogue beforeSpraypaintObserveDialogue;

    public Dialogue afterSpraypaintInteractDialogue;

    public Dialogue afterSpraypaintObserveDialogue;

    public Dialogue finalSpraypaintInteractDialogue;

    public Dialogue finalSpraypaintObserveDialogue;

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
        if (narrativeManager.SpraypaintReceived)
        {
            if (final == 0)
            {
                if (observe == false)
                {
                    narrativeManager.CameraSpraypainted = true;
                    FindObjectOfType<dialogueManager>().StartDialogue(afterSpraypaintInteractDialogue);
                    final = 1;
                }

                if (observe == true)
                {
                    FindObjectOfType<dialogueManager>().StartDialogue(afterSpraypaintObserveDialogue);
                }
            }
            else
            {
                if (observe == false)
                {
                    narrativeManager.CameraSpraypainted = true;
                    FindObjectOfType<dialogueManager>().StartDialogue(finalSpraypaintInteractDialogue);
                    final = 1;
                }

                if (observe == true)
                {
                    FindObjectOfType<dialogueManager>().StartDialogue(finalSpraypaintObserveDialogue);
                }
            }
        }
        else
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeSpraypaintInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeSpraypaintObserveDialogue);
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
