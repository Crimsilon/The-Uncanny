using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class julietScript : MonoBehaviour {

    private bool inTrigger = false;

    private bool keysEnabled;

    public GameObject dialogueBox;

    public GameObject observeInteract;

    public GameObject scene;

    public Dialogue beforeVolumeInteractDialogue;

    public Dialogue beforeVolumeObserveDialogue;

    public Dialogue beforeJulietInteractDialogue;

    public Dialogue beforeJulietObserveDialogue;

    public Dialogue afterJulietInteractDialogue;

    public Dialogue afterJulietObserveDialogue;

    public Dialogue pigCutscene;

    public bool observe = false;

    public narrativeManager narrativeManager;

    public int dialogueCount = 0;

    public int dialogueTotal1 = 13;

    public int dialogueTotal2 = 8;

    public bool canInteract = false;

    // Use this for initialization
    void Start()
    {
        keysEnabled = true;
        dialogueBox.SetActive(false);
        observeInteract.SetActive(false);
    }

    public void TriggerDialogue()
    {
        if (narrativeManager.VolumeDown && narrativeManager.JulietTalkedTo)
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(afterJulietInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(afterJulietObserveDialogue);
            }
        }
        else if (narrativeManager.VolumeDown && narrativeManager.JulietTalkedTo != true)
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(beforeJulietInteractDialogue);
                narrativeManager.JulietTalkedTo = true;
                canInteract = true;
                StartCoroutine(cutscene());
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
        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true)
        {
            dialogueCount = dialogueCount + 1;
        }
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

    IEnumerator cutscene()
    {
        yield return new WaitUntil(() => dialogueCount >= dialogueTotal1);
        dialogueCount = 0;
        yield return new WaitForSeconds(3f);
        keysEnabled = false;
        dialogueBox.SetActive(true);
        FindObjectOfType<dialogueManager>().StartDialogue(pigCutscene);
        canInteract = true;
        Time.timeScale = 0;
        yield return new WaitUntil(() => dialogueCount >= dialogueTotal2);
        keysEnabled = true;
        dialogueBox.SetActive(false);
        canInteract = false;
        Time.timeScale = 1;
        dialogueCount = 0;
    }
}
