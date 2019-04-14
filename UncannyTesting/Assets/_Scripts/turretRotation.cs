using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class turretRotation : MonoBehaviour {
    public float speed = 2f;

    public float maxRotation = 45f;

    private Ray raycast;

    public bool playerInRange = false;

    public GameObject player;

    public bool turretStart = true;

    public Transform target;

    public bool turretRotate = true;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (turretRotate == true)
        {
            transform.rotation = Quaternion.Euler(0f, maxRotation * Mathf.Sin(Time.time * speed), 0f);
        }
        if (turretRotate == false)
        {
            transform.LookAt(target);
        }

        if (playerInRange == true && turretStart == true)
        {
            turretStart = false;
            Vector3 fromPosition = this.transform.position;
            Vector3 toPosition = player.transform.position;
            Vector3 direction = toPosition - fromPosition;

            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(transform.position, direction, out hit))
            {
                print("!");
                if (hit.collider.gameObject.tag == "Player")
                {
                    turretRotate = false;
                    print("Whose footprints are these");
                    StartCoroutine(TimeToDie());
                    return;
                }
                else
                {
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            turretStart = true;
        }
    }

    IEnumerator TimeToDie()
    {
        yield return new WaitForSeconds(1.5f);
        //if (playerInRange == true)
        //{
        //    print("You are dead.");
        //    turretRotate = true;
        //}
        //else
        //{
        //    print("Must have been my imagination.");
        //    turretRotate = true;
        //}
        HitConfirmation();
    }

    public void HitConfirmation() {
        Vector3 fromPosition = this.transform.position;
        Vector3 toPosition = player.transform.position;
        Vector3 direction = toPosition - fromPosition;

        RaycastHit hitConfirm = new RaycastHit();

        if (Physics.Raycast(transform.position, direction, out hitConfirm))
        {
            if (hitConfirm.collider.gameObject.tag == "Player")
            {
                print("You are dead");
                turretRotate = true;
            }
            else
            {
                print("Must have been my imagination");
                turretStart = true;
                turretRotate = true;
                return;
            }
        }
    }
}