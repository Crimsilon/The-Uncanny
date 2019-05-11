using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class introScene : MonoBehaviour {

    public Image fade;

    public Animator fadeAnim;

    public GameObject dialogueBox;

    public Dialogue introScript1;

    public Dialogue introScript2;

    public playerController playerController;

    public GameObject player;

    public Rigidbody playerBody;

    public Animator playerAnim;

    Vector3 m_ZAxis;

    Vector3 playerStart;

    Vector3 playerCurrent;

    public bool finishWalking1 = false;

    public bool finishWalking2 = false;

    public int dialogueCount1 = 0;

    public int totalDialogue1 = 2;

    public int dialogueCount2 = 0;

    public int totalDialogue2 = 2;

    public bool canInteract;

    public bool firstHalf = true;

    // Use this for initialization
    void Start () {
        m_ZAxis = new Vector3(0, 0, 3.125f);
        playerStart = player.transform.position;
        StartCoroutine(introCutscene());
        canInteract = false;
    }
	
	// Update is called once per frame
	void Update () {
        playerCurrent = player.transform.position;

        if (playerCurrent.z >= playerStart.z + 1)
        {
            finishWalking1 = true;
        }

        if (playerCurrent.z >= playerStart.z + 2)
        {
            finishWalking2 = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true && firstHalf == true)
        {
            dialogueCount1 = dialogueCount1 + 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canInteract == true && firstHalf == false)
        {
            dialogueCount2 = dialogueCount2 + 1;
        }
    }

    IEnumerator introCutscene()
    {
        playerController.inScene = true;
        playerAnim.SetBool("isWalking", true);
        playerBody.velocity = m_ZAxis;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        player.transform.rotation = rotation;
        playerBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        yield return new WaitUntil(() => finishWalking1 == true);
        playerAnim.SetBool("isWalking", false);
        playerBody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSecondsRealtime(1f);
        canInteract = true;
        dialogueBox.SetActive(true);
        FindObjectOfType<dialogueManager>().StartDialogue(introScript1);
        Time.timeScale = 0;
        yield return new WaitUntil(() => dialogueCount1 >= totalDialogue1);
        firstHalf = false;
        canInteract = false;
        dialogueBox.SetActive(false);
        Time.timeScale = 1;
        playerBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        playerAnim.SetBool("isWalking", true);
        playerBody.velocity = m_ZAxis;
        player.transform.rotation = rotation;
        yield return new WaitUntil(() => finishWalking2 == true);
        playerAnim.SetBool("isWalking", false);
        playerBody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSecondsRealtime(0.5f);
        canInteract = true;
        dialogueBox.SetActive(true);
        FindObjectOfType<dialogueManager>().StartDialogue(introScript2);
        Time.timeScale = 0;
        yield return new WaitUntil(() => dialogueCount2 >= totalDialogue2);
        canInteract = false;
        dialogueBox.SetActive(false);
        Time.timeScale = 1;
        playerController.inScene = false;
    }
}
