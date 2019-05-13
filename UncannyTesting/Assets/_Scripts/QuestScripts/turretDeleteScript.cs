using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretDeleteScript : MonoBehaviour
{

    private bool inTrigger = false;

    private bool keysEnabled;

    public GameObject dialogueBox;

    public GameObject observeInteract;

    public GameObject scene;

    public Dialogue InteractDialogue;

    public Dialogue ObserveDialogue;

    public Dialogue noGunInteractDialogue;

    public bool observe = false;

    public narrativeManager narrativeManager;

    public BoxCollider turret;

    public turretRotation turretBody;

    // Use this for initialization
    void Start()
    {
        keysEnabled = true;
        dialogueBox.SetActive(false);
        observeInteract.SetActive(false);
    }

    public void TriggerDialogue()
    {
        if (narrativeManager.GunFound)
        {
            if (observe == false)
            {
                narrativeManager.GunFound = true;
                FindObjectOfType<dialogueManager>().StartDialogue(InteractDialogue);
                Destroy(turret);
                Destroy(turretBody);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(ObserveDialogue);
            }
        }
        else
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(noGunInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(ObserveDialogue);
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
            Destroy(turret);
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

