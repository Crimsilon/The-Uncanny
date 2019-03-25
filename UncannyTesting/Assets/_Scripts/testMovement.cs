using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovement : MonoBehaviour {

    public Transform[] waypoint;

    public bool loop = true;

    public float dampingLook = 6.0f;

    public float pauseDuration = 0.0f;

    public float patrolSpeed = 3.0f;

    private float curTime;

    private int currentWaypoint = 0;

    private CharacterController character;
 
    void Start() {
        character = GetComponent<CharacterController>();
    }

    void Update () {
        if (currentWaypoint < waypoint.Length)
        {
            Patrol();
        }
        else
        {
            if (loop == true)
            {
                currentWaypoint = 0;
            }
        }
    }

    void Patrol()
    {
        Vector3 target = waypoint[currentWaypoint].position;
        target.y = transform.position.y;
        Vector3 moveDirection = target - transform.position;

        if (moveDirection.magnitude < 0.5)
        {
            if (curTime == 0)
            {
                curTime = Time.time;
            }
            else if ((Time.time - curTime) >= pauseDuration)
            {
                currentWaypoint++;
                curTime = 0;
            }
        }
        else
        {
            var rotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * dampingLook);
            character.Move(moveDirection.normalized * patrolSpeed * Time.deltaTime);
        }
    }
}
