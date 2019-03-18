using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorwayTeleportation : MonoBehaviour {

    public bool inDoorTrigger = false;

    public GameObject player;

    public Vector3 warpPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (inDoorTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
            StartCoroutine(teleportWait());
        }
	}

    IEnumerator teleportWait()
    {
        yield return new WaitForSecondsRealtime(2);
        player.transform.position = warpPoint;
        Time.timeScale = 1;
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
