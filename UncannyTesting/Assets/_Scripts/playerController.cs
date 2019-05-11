using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerController : MonoBehaviour {
    public float speed;

    private Rigidbody rb;

    Vector3 m_XAxis;
    Vector3 m_ZAxis;

    public bool direction = false;

    public GameObject player;

    public float yAngle = 0f;

    public Transform rotationForward;

    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    public bool inScene = false;

    Animator anim;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.Rotate(0, 0, 0);

        m_XAxis = new Vector3(speed, 0, 0);
        m_ZAxis = new Vector3(0, 0, speed);

        if (Input.GetKey(KeyCode.D) && inScene == false)
        {
            anim.SetBool("isWalking", true);
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rb.velocity = m_XAxis;
            Quaternion rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            transform.rotation = rotation;
        }

        else if (Input.GetKey(KeyCode.A) && inScene == false)
        {
            anim.SetBool("isWalking", true);
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rb.velocity = -m_XAxis;
            Quaternion rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
            transform.rotation = rotation;
        }
        else if (Input.GetKey(KeyCode.W) && inScene == false)
        {
            anim.SetBool("isWalking", true);
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rb.velocity = m_ZAxis;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            transform.rotation = rotation;
        }
        else if (Input.GetKey(KeyCode.S) && inScene == false)
        {
            anim.SetBool("isWalking", true);
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rb.velocity = -m_ZAxis;
            Quaternion rotation = Quaternion.LookRotation(Vector3.back, Vector3.up);
            transform.rotation = rotation;
        }

        else
        {
            if (inScene == false)
            {
                anim.SetBool("isWalking", false);
                rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed + 2.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed - 2.5f;
        }

        /// <summary>public Transform startMarker;

        ///public Transform player;
        ///
        ///public float x = 0f;
        ///public float y = 1.7064f;
        ///public float z = 0f;
        ///
        ///public Transform endMarker = new Vector3(x, y, z);
        ///
        ///public float speed = 1.0f;
        ///
        ///private float startTime;
        ///
        ///private float journeyLength;
        /// </summary>

        ///float speed = 1.5f;
        ///Vector3 position;
        ///Transform player;

        // Use this for initialization
        ///void Start () {
        ///position = transform.position;
        ///player = transform;

        ///}

        // Update is called once per frame
        ///void Update () {

        ///if (Input.GetKeyDown("w") && player.position == position)
        ///{
        ///position += Vector3.forward;
        ///}
        ///else if (Input.GetKeyDown("s") && player.position == position)
        ///{
        ///position += Vector3.back;
        ///}
        ///else if (Input.GetKeyDown("a") && player.position == position)
        ///{
        ///position += Vector3.left;
        ///}
        ///else if (Input.GetKeyDown("d") && player.position == position)
        ///{
        ///position += Vector3.right;
        ///}

        ///transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);

        ///}
    }
    }
