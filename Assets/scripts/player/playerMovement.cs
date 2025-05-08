using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; //Speed of the player movement
    public float jumpForce = 7.0f; //Jump force applied to the player
    public float rotationSpeed = 5.0f; //Rotation speed for arrow key input

    private Rigidbody rb;
    private bool isGrounded;

    public AudioSource audioSource;
    public AudioClip[] walkingSounds;

    public AudioSource doorSFX;

    bool usedAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // init audio source
        audioSource = GetComponent<AudioSource>();

        usedAudio = false;
    }

    void PlayRandomSound(AudioClip[] soundArray)
    {
        //if (isGrounded == true){
            if (!audioSource.isPlaying && soundArray.Length > 0 && isGrounded == true)
            {
                AudioClip clip = soundArray[Random.Range(0, soundArray.Length)];
                audioSource.PlayOneShot(clip);
            }
        //}
    }
    
    void FixedUpdate()
    {
        //WASD Movement controls
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward; // Move forward
            PlayRandomSound(walkingSounds);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward; // Move backward
            PlayRandomSound(walkingSounds);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= transform.right; // Move left
            PlayRandomSound(walkingSounds);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += transform.right; // Move right
            PlayRandomSound(walkingSounds);
        }

        // Normalize movement vector to prevent diagonal speed boost (change diagonal value which is the combined total of 2 keys ( roughly 1.41) into 1 to prevent speed boost when player drifts)
        if (movement.magnitude > 1)
        {
            movement.Normalize();
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

        if (Time.timeScale == 0)
        {
            doorSFX.Stop();
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor") //allow jumping when touching a "floor" object
        {
            isGrounded = true;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("doorLayer"))
        {
            Debug.Log("Collided with door layer!"); // Add behavior here
            if (usedAudio == false)
            {
                usedAudio = true;
                doorSFX.Play();
                CancelInvoke("stopAudio"); // Cancel any previous invocations of stopAudio
            }
        }
    }


    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "floor") //stop allowing jumping when stop touching a "floor" object
        {
            isGrounded = false;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("doorLayer"))
        {
            Debug.Log("Collided with door layer!"); // Add behavior here
            Invoke("stopAudio", 1f); // Stop the sound after 0.5 seconds
        }
    }

    void stopAudio()
    {
        doorSFX.Stop();
        usedAudio = false;
    }

}
