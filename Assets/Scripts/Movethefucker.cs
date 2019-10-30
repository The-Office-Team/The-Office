using UnityEngine;
using System;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movethefucker : MonoBehaviour
{
    CharacterController characterController;

    public bool Teleporting = false;
    public float speed = 3.0f;
    public float runspeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public GameObject PlyCam;
    AudioSource asrc;
    public AudioClip RunSnd;
    public AudioClip WalkSnd;
    bool moving;

    private Vector3 moveDirection = Vector3.zero;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        asrc = GetComponent<AudioSource>();
        //PlyCam = GameObject.Find("Player Camera");
    }

    void Update()
    {
        //transform.eulerAngles = new Vector3(0.0f, PlyCam.transform.eulerAngles.y, 0.0f);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            bool wasplaying = asrc.isPlaying;
            asrc.clip = RunSnd;
            if ( wasplaying )
                asrc.Play();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            bool wasplaying = asrc.isPlaying;
            asrc.clip = WalkSnd;
            if (wasplaying)
                asrc.Play();
        }
        if (characterController.isGrounded)
        {
            if (characterController.velocity.magnitude > 1 && !moving)
            {
                asrc.Play();
                moving = true;
            }
            else if (characterController.velocity.magnitude < 1)
            {
                moving = false;
                asrc.Stop();
            }
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(transform.forward.x, 0.0f, transform.forward.z) * Input.GetAxis("Vertical");
            moveDirection += transform.right * Input.GetAxis("Horizontal");
            moveDirection *= Input.GetKey(KeyCode.LeftShift) ? runspeed : speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        if (Teleporting == false)
        {
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}