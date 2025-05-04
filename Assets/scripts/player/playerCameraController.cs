using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCameraController : MonoBehaviour
{

    public Camera cam;
    public float settingsFOV;


    // Update is called once per frame
    void FixedUpdate()
    {
        settingsFOV = PlayerPrefs.GetFloat("camFOV");
        cam.fieldOfView = settingsFOV;
    }
}

