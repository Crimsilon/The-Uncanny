﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleInformation : MonoBehaviour
{

    private bool inTrigger = false;

    private bool keysEnabled;

    public GameObject dialogueBox;

    public GameObject observeText;

    public GameObject interactText1;

    public GameObject interactText2;

    public GameObject keyObject;

    public bool keyGet;

    // Use this for initialization
    void Start()
    {
        keysEnabled = true;
        dialogueBox.SetActive(false);
        observeText.SetActive(false);
        interactText1.SetActive(false);
        interactText2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (inTrigger == true && Input.GetKeyDown(KeyCode.Q) && keysEnabled == true)
        {
            ///StartCoroutine(observeActivate());
            ///Debug.Log("You are observing the Jeffko object");
            keysEnabled = false;
            dialogueBox.SetActive(true);
            observeText.SetActive(true);
            Time.timeScale = 0;
        }

        if (inTrigger == true && Input.GetKeyDown(KeyCode.E) && keysEnabled == true)
        {
            ///StartCoroutine(interactActivate());
            ///Debug.Log("You are interacting with the Jeffko object");
            keysEnabled = false;
            dialogueBox.SetActive(true);
            interactText1.SetActive(true);
            Time.timeScale = 0;

        }

        if ((Time.timeScale == 0) && Input.GetKeyDown(KeyCode.Space) && keysEnabled == false)
        {
            Time.timeScale = 1;
            dialogueBox.SetActive(false);
            observeText.SetActive(false);
            interactText1.SetActive(false);
            interactText2.SetActive(false);
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
