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

    public Dialogue introScript;

    public playerController playerController;

    public GameObject player;

    public Rigidbody playerBody;

    public Animator playerAnim;

    Vector3 m_ZAxis;

    Vector3 playerStart;

    Vector3 playerCurrent;

    public bool finishWalking = false;

    // Use this for initialization
    void Start () {
        m_ZAxis = new Vector3(0, 0, 3.125f);
        playerStart = player.transform.position;
        StartCoroutine(introCutscene());
    }
	
	// Update is called once per frame
	void Update () {
        playerCurrent = player.transform.position;

        if (playerCurrent.z >= playerStart.z + 2)
        {
            finishWalking = true;
        }
	}

    IEnumerator introCutscene()
    {
        playerController.inScene = true;
        playerAnim.SetBool("isWalking", true);
        playerBody.velocity = m_ZAxis;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        player.transform.rotation = rotation;
        yield return new WaitUntil(() => finishWalking == true);
        playerAnim.SetBool("isWalking", false);
        yield return new WaitForSecondsRealtime(1f);
        dialogueBox.SetActive(true);
        FindObjectOfType<dialogueManager>().StartDialogue(introScript);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        dialogueBox.SetActive(false);
        Time.timeScale = 1;
        playerController.inScene = false;
    }
}
