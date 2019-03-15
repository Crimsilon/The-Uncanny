using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovement : MonoBehaviour {

	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
