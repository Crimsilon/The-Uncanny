﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class methManager : MonoBehaviour {

    public bool red = false;

    public bool white = false;

    public bool clear = false;

    public Dialogue wrong;

    public GameObject dialogueBox;

    public narrativeManager narrativeManager;

    public finalCutscene finalCutscene;

    public int ingredientCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ingredientCount == 3)
        {
            if (red == true && white == true && clear == true)
            {
                finalCutscene.begin = true;
            }
            else
            {
                Time.timeScale = 0;
                dialogueBox.SetActive(true);
                FindObjectOfType<dialogueManager>().StartDialogue(wrong);
                red = false;
                white = false;
                clear = false;
                ingredientCount = 0;
            }
        }
    }
}
