using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discoFloorSwap : MonoBehaviour {

    public GameObject discoFloorTile;

    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;

    int rNumber = 1;

    public bool isSwapping;

	// Use this for initialization
	void Start () {
        isSwapping = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isSwapping == false)
        {
            isSwapping = true;
            StartCoroutine(FloorSwap());
        }
        else
        {

        }
	}

    IEnumerator FloorSwap()
    {
        yield return new WaitForSeconds(0.8f);
        rNumber = Random.Range(1, 4);
        if (rNumber == 1)
        {
            discoFloorTile.GetComponent<MeshRenderer>().material = Material1;
        }
        else if (rNumber == 2)
        {
            discoFloorTile.GetComponent<MeshRenderer>().material = Material2;
        }
        else if (rNumber == 3)
        {
            discoFloorTile.GetComponent<MeshRenderer>().material = Material3;
        }
        else if (rNumber == 4)
        {
            discoFloorTile.GetComponent<MeshRenderer>().material = Material4;
        }
        isSwapping = false;
    }
}
