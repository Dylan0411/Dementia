using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;

    public Rigidbody rb;
    public float move;


    void Start()
    {
        move = 0;
        speed = 35.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * move * speed);
    }
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.W)) {
            move = 0.0f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            move = 0.0f;
        }
        //"wasd" movement controls
        if (Input.GetKey(KeyCode.W))
        {
            move = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move = -1.0f;
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
