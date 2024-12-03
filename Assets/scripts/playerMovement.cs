using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private float acceleration;

    public Rigidbody rb;


    void Start()
    {
        speed = 35.0f;
        acceleration = 0.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (acceleration < 0.0f) { acceleration += 0.05f; };
        //if (acceleration > 0.0f) { acceleration *= 0.99f; acceleration -= 0.05f; };
        acceleration = 0.0f;
    }
    void FixedUpdate()
    {

        //"wasd" movement controls
        if (Input.GetKey(KeyCode.W))
        {
            acceleration += 0.06f;
            acceleration = acceleration / 0.99f;
            if (acceleration < 1.0f) { acceleration *= 1.9f; };
            rb.AddForce(transform.forward * speed * acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            acceleration += 0.06f;
            acceleration = acceleration / 0.99f;
            if (acceleration < 1.0f) { acceleration *= 1.2f; };
            rb.AddForce(-transform.forward * speed * acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -5, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 5, 0);
        }
    }
}
