using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; //Speed of the player movement
    public float jumpForce = 7.0f; //Jump force applied to the player
    public float rotationSpeed = 5.0f; //Rotation speed for arrow key input

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //WASD Movement controls
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward; // Move forward
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward; // Move backward
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= transform.right; // Move left
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right; // Move right
        }

        //the actual math of the movement
        rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);
    }

    void Update()
    {
        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor") //allow jumping when touching a "floor" object
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "floor") //stop allowing jumping when stop touching a "floor" object
        {
            isGrounded = false;
        }
    }

}
