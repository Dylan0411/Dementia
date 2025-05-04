using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    //for camera movement
    public float sensX;
    public float sensY;
    float xRotation;
    float yRotation;
    public Transform orientation;
    int invX;
    int invY;
    private void Start()
    {
        //for camera stuff
        Cursor.lockState = CursorLockMode.Locked; //Locks cursor to middle of the screen
        Cursor.visible = false;

        //Retrieve player save data (sensitivity/inversion)
        sensX = PlayerPrefs.GetFloat("sensitivityX", 0);
        sensY = PlayerPrefs.GetFloat("sensitivityY", 0);
        invX = PlayerPrefs.GetInt("invertedX", 0);
        invY = PlayerPrefs.GetInt("invertedY", 0);
    }

    private void Update()
    {
        //Retrieve player save data (sensitivity/inversion)
        sensX = PlayerPrefs.GetFloat("sensitivityX");
        sensY = PlayerPrefs.GetFloat("sensitivityY");
        invX = PlayerPrefs.GetInt("invertedX");
        invY = PlayerPrefs.GetInt("invertedY");

        //apply sensitivity
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        //apply inversion
        if (invX == 1)
        {
            xRotation -= mouseX;
        }
        if (invX == 0)
        {
            xRotation += mouseX;
        }
        if (invY == 0) //i swapped these to fix a bug?
        {
            yRotation -= mouseY;
        }
        if (invY == 1) //i swapped these to fix a bug?
        {
            yRotation += mouseY;
        }
        //camera control stuff
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(0, xRotation, 0); //Rotates the player
        orientation.rotation = Quaternion.Euler(yRotation, xRotation, 0); //Rotates the camera object
    }
}
