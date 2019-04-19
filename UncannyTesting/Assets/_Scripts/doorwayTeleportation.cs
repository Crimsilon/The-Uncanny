using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class doorwayTeleportation : MonoBehaviour {

    public bool inDoorTrigger = false;

    public GameObject player;

    public Vector3 warpPoint;

    public Image myPanel;
    float fadeTime = 0.5f;
    Color colorToFadeTo;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (inDoorTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            colorToFadeTo = new Color(0f, 0f, 0f, 1f);
            myPanel.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
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
        myPanel.CrossFadeColor(colorToFadeTo, fadeTime, true, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("inTrigger is true");
            inDoorTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("inTrigger is false");
            inDoorTrigger = false;
        }
    }
}
