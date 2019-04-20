﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class objectInformation : MonoBehaviour {

//    private bool inTrigger = false;

//    private bool keysEnabled;

//    public GameObject dialogueBox;

//    public GameObject observeText;

//    public GameObject interactText;

//    public GameObject scene;

//    private bool pauseTime;

//    // Use this for initialization
//	void Start () {
//        keysEnabled = true;
//        dialogueBox.SetActive(false);
//        observeText.SetActive(false);
//        interactText.SetActive(false);
//        pauseTime = false;
//    }

//    // Update is called once per frame
//    void Update () {
//        if (inTrigger == true && Input.GetKeyDown(KeyCode.Q) && keysEnabled == true)
//        {
//            ///StartCoroutine(observeActivate());
//            ///Debug.Log("You are observing the Jeffko object");
//            keysEnabled = false;
//            dialogueBox.SetActive(true);
//            observeText.SetActive(true);
//            Time.timeScale = 0;
//        }

//        if (inTrigger == true && Input.GetKeyDown(KeyCode.E) && keysEnabled == true)
//        {
//            ///StartCoroutine(interactActivate());
//            ///Debug.Log("You are interacting with the Jeffko object");
//            keysEnabled = false;
//            dialogueBox.SetActive(true);
//            interactText.SetActive(true);
//            Time.timeScale = 0;

//        }

//        if ((Time.timeScale == 0) && Input.GetKeyDown(KeyCode.Space) && keysEnabled == false)
//        {
//            Time.timeScale = 1;
//            dialogueBox.SetActive(false);
//            observeText.SetActive(false);
//            interactText.SetActive(false);
//            keysEnabled = true;
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.CompareTag("Player"))
//        {
//            Debug.Log("inTrigger is true");
//            inTrigger = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.gameObject.CompareTag("Player"))
//        {
//            Debug.Log("inTrigger is false");
//            inTrigger = false;
//        }
//    }

//    ///IEnumerator observeActivate()
//    ///{
//        ///dialogueBox.SetActive(true);
//        ///observeText.SetActive(true);
//        ///Time.timeScale = 0;
//        ///yield return new WaitUntil(pauseTime == true);
//        ///dialogueBox.SetActive(false);
//        ///observeText.SetActive(false);
//    ///}

//    ///IEnumerator interactActivate()
//    ///{
//        ///dialogueBox.SetActive(true);
//        ///interactText.SetActive(true);
//        ///yield return new WaitForSeconds(3.0f);
//        ///dialogueBox.SetActive(false);
//        ///interactText.SetActive(false);
//    ///}
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clubNPCInformation : MonoBehaviour
{

    private bool inTrigger = false;

    private bool keysEnabled;

    public GameObject dialogueBox;

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
    }

    public void TriggerDialogue()
    {
        if (narrativeManager.VolumeDown) {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(lowVolumeInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(lowVolumeObserveDialogue);
            }
        }
        else
        {
            if (observe == false)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(highVolumeInteractDialogue);
            }

            if (observe == true)
            {
                FindObjectOfType<dialogueManager>().StartDialogue(highVolumeObserveDialogue);
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

    ///IEnumerator observeActivate()
    ///{
    ///dialogueBox.SetActive(true);
    ///observeText.SetActive(true);
    ///Time.timeScale = 0;
    ///yield return new WaitUntil(pauseTime == true);
    ///dialogueBox.SetActive(false);
    ///observeText.SetActive(false);
    ///}

    ///IEnumerator interactActivate()
    ///{
    ///dialogueBox.SetActive(true);
    ///interactText.SetActive(true);
    ///yield return new WaitForSeconds(3.0f);
    ///dialogueBox.SetActive(false);
    ///interactText.SetActive(false);
    ///}
}
