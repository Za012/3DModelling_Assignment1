using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 4f;
    public float gravity = -19.62f;
    public float jumpHeight = 1.5f;


    public Vector3 velocity;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Walk()
    {
        velocity.x = Input.GetAxis("Horizontal") * speed;
        velocity.z = Input.GetAxis("Vertical") * speed;

        rb.velocity = velocity;
    }

    void Update()
    {

        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Walk();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isGrounded = false;
        }

        velocity.y += gravity * Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}

