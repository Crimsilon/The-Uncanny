using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;
    private Queue<string> names;

    public bool nextSentence = false;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        names = new Queue<string>();
	}

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        names.Clear();
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.name)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            Time.timeScale = 1;
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        Debug.Log(sentence);
        nameText.text = name;
        dialogueText.text = sentence;
        nextSentence = true;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && nextSentence == true)
        {
            nextSentence = false;
            DisplayNextSentence();
        }
    }
}
