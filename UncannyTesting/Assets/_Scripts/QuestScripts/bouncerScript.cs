using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

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

    public Dialogue finalInteractDialogue;

    public Dialogue finalObserveDialogue;

    public bool observe = false;

    public narrativeManager narrativeManager;

    public GameObject player;

    public Vector3 warpPoint;

    public Image myPanel;

    public Animator anim;

    public bool canInteract = false;

    public int dialogueCount = 0;

    public int totalDialogue = 6;

    public int totalFinalDialogue = 1;

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
        if (narrativeManager.BouncerTalkedTo && narrativeManager.BabeFound)
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(afterBabeInteractDialogue);
                canInteract = true;
                StartCoroutine(transitionTime());
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
        if (final >= 1)
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(finalInteractDialogue);
                canInteract = true;
                StartCoroutine(transitionTime2());
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(finalObserveDialogue);
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

    IEnumerator transitionTime()
    {
        yield return new WaitUntil(() => dialogueCount >= totalDialogue);
        Time.timeScale = 0;
        anim.SetBool("fadeOut", true);
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;
        player.transform.position = warpPoint;
        anim.SetBool("fadeOut", false);
        dialogueCount = 0;
        final = 1;
    }

    IEnumerator transitionTime2()
    {
        yield return new WaitUntil(() => dialogueCount >= totalFinalDialogue);
        Time.timeScale = 0;
        anim.SetBool("fadeOut", true);
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;
        player.transform.position = warpPoint;
        anim.SetBool("fadeOut", false);
        dialogueCount = 0;
        final = 1;
    }
}
