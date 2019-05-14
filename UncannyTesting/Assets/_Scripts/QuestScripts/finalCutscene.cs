using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

[System.Serializable]
public class finalCutscene : MonoBehaviour {

    public int noRepeat = 0;

    public bool begin = false;

    public playerController playerController;

    public GameObject player;

    public GameObject Damien;

    public GameObject crate;

    public Transform cratePosition;

    public GameObject dialogueBox;

    public Dialogue potionDialogue;

    public Dialogue officeDialogueFirstHalf;

    public Dialogue officeDialogueSecondHalf;

    public int dialogueCount = 0;

    public int potionDialogueTotal = 6;

    public int officeFirstHalfTotal = 13;

    public int officeSecondHalfTotal = 20;

    public bool canInteract;

    public Vector3 officeWarpJack;

    public Image myPanel;

    public Animator anim;

    public float speedFollow = 2f;

    private Vector3 nextDir;

    private float step;

    private Vector3 nextDir2;

    private float step2;

    // Use this for initialization
    void Start () {
        Damien.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetDir = crate.transform.position - Damien.transform.position;

        float step = speedFollow * Time.deltaTime;

        Vector3 nextDir = new Vector3(targetDir.x, 0.0f, targetDir.z);

        Vector3 targetDir2 = player.transform.position - Damien.transform.position;
        step2 = speedFollow * Time.deltaTime;
        nextDir2 = new Vector3(targetDir2.x, 0.0f, targetDir2.z);

        if (begin == true && noRepeat == 0)
        {
            playerController.inScene = true;
            noRepeat = 1;
            StartCoroutine(beginEnd());
        }
        if (canInteract == true && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueCount = dialogueCount + 1;
        }
	}

    IEnumerator beginEnd()
    {
        anim.SetBool("fadeOut", true);
        dialogueBox.SetActive(true);
        canInteract = true;
        Time.timeScale = 0;
        FindObjectOfType<dialogueManager>().StartDialogue(potionDialogue);
        yield return new WaitUntil(() => dialogueCount >= potionDialogueTotal);
        Time.timeScale = 1;
        dialogueCount = 0;
        canInteract = false;
        dialogueBox.SetActive(false);
        player.transform.position = officeWarpJack;
        Damien.SetActive(true);
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        player.transform.rotation = rotation;
        anim.SetBool("fadeOut", false);
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0;
        canInteract = true;
        dialogueBox.SetActive(true);
        FindObjectOfType<dialogueManager>().StartDialogue(officeDialogueFirstHalf);
        yield return new WaitUntil(() => dialogueCount >= officeFirstHalfTotal);
        Time.timeScale = 1;
        dialogueCount = 0;
        canInteract = false;
        dialogueBox.SetActive(false);
        Vector3 newDir = Vector3.RotateTowards(Damien.transform.forward, nextDir, step, 0.0f);
        Damien.transform.rotation = Quaternion.LookRotation(newDir);
        yield return new WaitForSecondsRealtime(1f);
        Vector3 newDir2 = Vector3.RotateTowards(Damien.transform.forward, nextDir2, step2, 0.0f);
        Damien.transform.rotation = Quaternion.LookRotation(newDir2);
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0;
        dialogueBox.SetActive(true);
        canInteract = true;
        FindObjectOfType<dialogueManager>().StartDialogue(officeDialogueSecondHalf);
        yield return new WaitUntil(() => dialogueCount >= officeSecondHalfTotal);
        Time.timeScale = 1;
        dialogueBox.SetActive(false);
        anim.SetBool("fadeOut", true);
        yield return new WaitForSecondsRealtime(2f);
        Application.Quit();
    }
}
