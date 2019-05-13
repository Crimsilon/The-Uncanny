using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

[System.Serializable]
public class sewerScript : MonoBehaviour
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

    public playerController playerController;



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
        if (playerController.inScene)
        {

        }
        else
        {
            if (narrativeManager.CrowbarFound)
            {
                if (inDoorTrigger == true && Input.GetKeyDown(KeyCode.E))
                {
                    if (final == 0)
                    {
                        interactPrompt.SetActive(false);
                        anim.SetBool("fadeOut", true);
                        FindObjectOfType<dialogueManager>().StartDialogue(canPass);
                        Time.timeScale = 0;
                        final = 1;
                        StartCoroutine(teleportWait1());
                    }
                    else
                    {
                        interactPrompt.SetActive(false);
                        anim.SetBool("fadeOut", true);
                        Time.timeScale = 0;
                        final = 1;
                        StartCoroutine(teleportWait());
                    }
                }
            }
            else
            {
                if (inDoorTrigger == true && Input.GetKeyDown(KeyCode.E))
                {
                    Time.timeScale = 0;
                    dialogueBox.SetActive(true);
                    FindObjectOfType<dialogueManager>().StartDialogue(cannotPass);
                    interactPrompt.SetActive(false);
                    narrativeManager.CameraChecked = true;
                }
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

    IEnumerator teleportWait1()
    {
        yield return new WaitUntil(() => dialogueCount >= dialogueTotal1);
        anim.SetBool("fadeOut", true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        player.transform.position = warpPoint;
        Time.timeScale = 1;
        dialogueCount = 0;
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