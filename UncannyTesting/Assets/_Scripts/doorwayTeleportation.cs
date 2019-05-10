using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class doorwayTeleportation : MonoBehaviour {

    public bool inDoorTrigger = false;

    public GameObject player;

    public Vector3 warpPoint;

    public GameObject interactPrompt;

    public Image myPanel;

    public Animator anim;

    

    // Use this for initialization
    void Start () {
        interactPrompt.SetActive(false);
        anim.SetBool("fadeOut", false);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (inDoorTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            interactPrompt.SetActive(false);
            anim.SetBool("fadeOut", true);
            Time.timeScale = 0;
            StartCoroutine(teleportWait());
        }
	}

    IEnumerator teleportWait()
    {
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
