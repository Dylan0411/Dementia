using UnityEngine;

public class playerLook : MonoBehaviour
{
    public Transform orientation;

    public float sensX;
    public float sensY;
    float xRotation;
    float yRotation;

    //public GameObject playerHead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Locks cursor to middle of the screen
        Cursor.visible = false; //hides cursor
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * -sensY;
        xRotation += mouseX;
        yRotation += mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(0, xRotation, 0); //Rotates the player
        orientation.rotation = Quaternion.Euler(yRotation, xRotation, 0); //Rotates the camera object
    }
}
