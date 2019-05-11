using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class stairwayDoorScript : MonoBehaviour
{

    public bool inDoorTrigger = false;

    public GameObject player;

    public Vector3 warpPoint;

    public GameObject interactPrompt;

    public Dialogue cannotPass;

    public Dialogue canPass;

    public int final = 0;

    public Image myPanel;

    public Animator anim;

    public narrativeManager narrativeManager;

    public GameObject dialogueBox;

    public int dialogueCount = 0;

    public int dialogueTotal1;

    public int dialogueTotal2;

    public bool canInteract = false;



    // Use this for initialization
    void Start()
    {
        interactPrompt.SetActive(false);
        anim.SetBool("fadeOut", false);
        dialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true)
        {
            dialogueCount = dialogueCount + 1;
        }

        if (narrativeManager.RyanTalkedTo)
        {
            if (final == 0)
            {
                if (inDoorTrigger == true && Input.GetKeyDown(KeyCode.E))
                {
                    interactPrompt.SetActive(false);
                    Time.timeScale = 0;
                    dialogueBox.SetActive(true);
                    canInteract = true;
                    FindObjectOfType<dialogueManager>().StartDialogue(canPass);
                    interactPrompt.SetActive(false);
                    final = 1;
                    StartCoroutine(teleportWait2());
                }
            }
            else
            {
                if (inDoorTrigger == true && Input.GetKeyDown(KeyCode.E))
                {
                    interactPrompt.SetActive(false);
                    anim.SetBool("fadeOut", true);
                    Time.timeScale = 0;
                    StartCoroutine(teleportWait());
                }
            }
        }
        else
        {
            if (inDoorTrigger == true && Input.GetKeyDown(KeyCode.E))
            {
                interactPrompt.SetActive(false);
                dialogueBox.SetActive(true);
                Time.timeScale = 0;
                FindObjectOfType<dialogueManager>().StartDialogue(cannotPass);
            }
        }
    }

    IEnumerator teleportWait()
    {
        yield return new WaitForSecondsRealtime(2);
        player.transform.position = warpPoint;
        Time.timeScale = 1;
        anim.SetBool("fadeOut", false);
    }

    IEnumerator teleportWait2()
    {
        yield return new WaitUntil(() => dialogueCount >= dialogueTotal2);
        anim.SetBool("fadeOut", true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        player.transform.position = warpPoint;
        Time.timeScale = 1;
        anim.SetBool("fadeOut", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactPrompt.SetActive(true);
            Debug.Log("inTrigger is true");
            inDoorTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactPrompt.SetActive(false);
            Debug.Log("inTrigger is false");
            inDoorTrigger = false;
        }
    }
}

