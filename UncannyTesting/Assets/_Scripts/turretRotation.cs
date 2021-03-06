﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEditor.Animations;
using UnityEngine.SceneManagement;

[System.Serializable]
public class turretRotation : MonoBehaviour {
    public float speed = 2f;

    public float speedFollow = 2f;

    public float maxRotation = 90f;

    private Ray raycast;

    public bool playerInRange = false;

    public GameObject player;

    public bool turretStart = true;

    public Transform target;

    public bool turretRotate = true;

    public Transform shotFire;

    private Rigidbody rb;

    public Transform point1;

    public Transform point2;

    Quaternion rotate;

    public Image death;

    public Animator anim;

    public Vector3 playerRespawn;

    public Vector3 m_from = new Vector3(0.0F, 105.0F, 0.0F);
    public Vector3 m_to = new Vector3(0.0F, 255.0F, 0.0F);

    public AudioClip startUp;

    public AudioClip shoot;

    public AudioSource MusicSource;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Vector3 targetDir = target.position - transform.position;

        float step = speedFollow * Time.deltaTime;

        Vector3 nextDir = new Vector3(targetDir.x, 0.0f, targetDir.z);

        if (turretRotate == true)
        {
            //transform.rotation = Quaternion.Euler(0f, (maxRotation * Mathf.Sin(Time.time * speed)), 0f);
            //transform.rotation = Quaternion.AngleAxis(maxRotation, Vector3.up);
            //transform.rotation = Quaternion.FromToRotation(Vector3.left, Vector3.right);
            //rotate.SetFromToRotation(point1.position, point2.position);
            //transform.rotation = rotate * transform.rotation;
            Quaternion from = Quaternion.Euler(this.m_from);
            Quaternion to = Quaternion.Euler(this.m_to);

            float lerp = 0.5F * (1.0F + Mathf.Sin(Mathf.PI * Time.realtimeSinceStartup * this.speed));
            this.transform.localRotation = Quaternion.Lerp(from, to, lerp);

        }
        if (turretRotate == false)
        {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, nextDir, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }

        if (playerInRange == true && turretStart == true)
        {
            turretStart = false;
            Vector3 fromPosition = shotFire.position;
            Vector3 toPosition = player.transform.position;
            Vector3 direction = toPosition - fromPosition;

            RaycastHit hit = new RaycastHit();
            Debug.DrawRay(transform.position, direction, Color.green, 2);

            if (Physics.Raycast(shotFire.position, direction, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    turretRotate = false;
                    MusicSource.clip = startUp;
                    MusicSource.Play();
                    print("Whose footprints are these");
                    StartCoroutine(TimeToDie());
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
        Vector3 fromPosition = shotFire.position;
        Vector3 toPosition = player.transform.position;
        Vector3 direction = toPosition - fromPosition;

        RaycastHit hitConfirm = new RaycastHit();

        if (Physics.Raycast(shotFire.position, direction, out hitConfirm))
        {
            if (hitConfirm.collider.gameObject.tag == "Player")
            {
                MusicSource.clip = shoot;
                MusicSource.Play();
                print("You are dead");
                anim.SetBool("dead", true);
                Time.timeScale = 0;
                StartCoroutine(Dead());
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

    IEnumerator Dead()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        anim.SetBool("dead", false);
        Time.timeScale = 1;
        player.transform.position = playerRespawn;
        turretRotate = true;
    }
}