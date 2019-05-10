using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class doorwayTeleportation : MonoBehaviour {

    public bool inDoorTrigger = false;

    public GameObject player;

    public Vector3 warpPoint;

    public GameObject interactPrompt;

    public Image myPanel;
    float fadeTime = 2.0f;
    public Color colorToFadeTo;

    // Use this for initialization
    void Start () {
        interactPrompt.SetActive(false);
        colorToFadeTo = new Color(0f, 0f, 0f, 0f);
        myPanel.CrossFadeColor(colorToFadeTo, fadeTime, true, false);
        Debug.Log("Well this should at least show");
    }
	
	// Update is called once per frame
	void Update () {
        if (inDoorTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            interactPrompt.SetActive(false);
            colorToFadeTo = new Color(0f, 0f, 0f, 255f);
            myPanel.CrossFadeColor(colorToFadeTo, fadeTime, false, false);
            Time.timeScale = 0;
            StartCoroutine(teleportWait());
        }
	}

    IEnumerator teleportWait()
    {
        yield return new WaitForSecondsRealtime(2);
        player.transform.position = warpPoint;
        Time.timeScale = 1;
        colorToFadeTo = new Color(0f, 0f, 0f, 0f);
        myPanel.CrossFadeColor(colorToFadeTo, fadeTime, false, false);
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
