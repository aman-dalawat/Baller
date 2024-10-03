using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControll : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float jumpHeight = 8f;
    public float movementSpeed = 5f;

    public AudioClip Hit01;
    public AudioClip Hit02;
    public AudioClip Hit03;

    private float distToGround;
    private AudioSource audioSource;

    // Add UI buttons with ButtonHold script
    public Button jumpButton;
    public Button forwardButton;
    public Button backwardButton;

    private float buttonMoveDir = 0f;

    private void Start()
    {
        if (checkPoint.ReachedPoint == Vector3.zero)
            checkPoint.ReachedPoint = transform.position;

        // Getting the distance from the center to the ground.
        distToGround = GetComponent<Collider>().bounds.extents.y;
        audioSource = GetComponent<AudioSource>();

        // Attach button click listeners
        jumpButton.onClick.AddListener(Jump);
        forwardButton.GetComponent<ButtonHold>().OnButtonHold.AddListener(MoveForward);
        forwardButton.GetComponent<ButtonHold>().OnButtonRelease.AddListener(StopMovement);
        backwardButton.GetComponent<ButtonHold>().OnButtonHold.AddListener(MoveBackward);
        backwardButton.GetComponent<ButtonHold>().OnButtonRelease.AddListener(StopMovement);
    }

    private void Update()
    {
        // Handle ball rotation.
        float moveDir = Input.GetAxis("Horizontal");
        if (Mathf.Abs(buttonMoveDir) > 0.01f)
            moveDir = buttonMoveDir;
        float rotation = moveDir * rotationSpeed * Time.deltaTime;
        GetComponent<Rigidbody>().AddRelativeTorque(Vector3.back * rotation);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, jumpHeight, GetComponent<Rigidbody>().velocity.z);
        }
    }

    public void MoveForward()
    {
        buttonMoveDir = 1f;
        // Move(Vector3.forward);
    }


    public void MoveBackward()
    {   
        buttonMoveDir = -1f;
        // Move(Vector3.back);
    }

    private void Move(Vector3 direction)
    {
        // Implement your movement logic here
        // For example, you can add force to the rigidbody in the specified direction
        // GetComponent<Rigidbody>().AddForce(direction * movementSpeed, ForceMode.Impulse);
    }

    public void StopMovement()
    {
        buttonMoveDir = 0f;
        // You can add any logic here to stop the continuous movement
        // For example, you might stop the rigidbody movement or set a flag to stop movement in the Update method.
    }

    private bool IsGrounded()
    {
        // Check if we are on the ground. Return true if we are, else return false.
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int theHit = Random.Range(0, 3);
        switch (theHit)
        {
            case 0:
                audioSource.clip = Hit01;
                break;
            case 1:
                audioSource.clip = Hit02;
                break;
            default:
                audioSource.clip = Hit03;
                break;
        }
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }
}
