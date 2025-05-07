using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Required for IEnumerator

public class cameraController : MonoBehaviour
{

    public GameObject cam;
    int pathCounter;

    float cameraMovementSpeed;


    public GameObject destinationPos1;
    public GameObject destinationPos2;
    public GameObject destinationPos3;
    public GameObject destinationPos4;
    public GameObject destinationPos5;

    public GameObject defaultPos1;
    public GameObject defaultPos2;
    public GameObject defaultPos3;
    public GameObject defaultPos4;
    public GameObject defaultPos5;

    public GameObject fadeZone1;
    public GameObject fadeZone2;
    public GameObject fadeZone3;
    public GameObject fadeZone4;
    public GameObject fadeZone5;

    public Image targetImage;
    public float fadeDuration = 1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pathCounter = 0;
        cameraMovementSpeed = 0.025f;
        //set starting position+rotation
        cam.transform.position = defaultPos1.transform.position;
        cam.transform.rotation = defaultPos1.transform.rotation;

        FadeOut();

        //unpause the game so animation actually works
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;//let the player move the cursor
        Cursor.visible = true; //show cursor
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("pathCounter = "+ pathCounter);

        if (pathCounter == 0)
        {
            //call a function to unfade the screne
            //FadeOut();

            Debug.Log("moving to destinationPos1");

            //move camera to cameraSettingsMenuPos.transform.position
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, destinationPos1.transform.position, cameraMovementSpeed);
            //rotate cam to match the rotation of cameraSettingsMenuPos.transform.position
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, destinationPos1.transform.rotation, cameraMovementSpeed);

            if (cam.transform.position == fadeZone1.transform.position)
            {
                //call a function to fade the screen
                FadeIn();
            }
            //show settings canvas when in position
            if (cam.transform.position == destinationPos1.transform.position)
            {
                //set starting position+rotation
                cam.transform.position = defaultPos2.transform.position;
                cam.transform.rotation = defaultPos2.transform.rotation;

                FadeOut();

                Debug.Log("at destinationPos1");
                pathCounter = 1;
            } 
        }
        if (pathCounter == 1)
        {
            //call a function to unfade the screne
            //FadeOut();

            Debug.Log("moving to destinationPos2");

            //move camera to cameraSettingsMenuPos.transform.position
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, destinationPos2.transform.position, cameraMovementSpeed);
            //rotate cam to match the rotation of cameraSettingsMenuPos.transform.position
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, destinationPos2.transform.rotation, cameraMovementSpeed);

            if (cam.transform.position == fadeZone2.transform.position)
            {
                //call a function to fade the screen
                FadeIn();
            }
            //show settings canvas when in position
            if (cam.transform.position == destinationPos2.transform.position)
            {
                //set starting position+rotation
                cam.transform.position = defaultPos3.transform.position;
                cam.transform.rotation = defaultPos3.transform.rotation;

                FadeOut();

                Debug.Log("at destinationPos2");
                pathCounter = 2;
            }
        }
        if (pathCounter == 2)
        {
            //call a function to unfade the screne
            //FadeOut();

            Debug.Log("moving to destinationPos3");

            //move camera to cameraSettingsMenuPos.transform.position
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, destinationPos3.transform.position, cameraMovementSpeed);
            //rotate cam to match the rotation of cameraSettingsMenuPos.transform.position
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, destinationPos3.transform.rotation, cameraMovementSpeed);

            if (cam.transform.position == fadeZone3.transform.position)
            {
                //call a function to fade the screen
                FadeIn();
            }
            //show settings canvas when in position
            if (cam.transform.position == destinationPos3.transform.position)
            {
                //set starting position+rotation
                cam.transform.position = defaultPos4.transform.position;
                cam.transform.rotation = defaultPos4.transform.rotation;

                FadeOut();

                Debug.Log("at destinationPos3");
                pathCounter = 3;
            }
        }
        if (pathCounter == 3)
        {
            //call a function to unfade the screne
            //FadeOut();

            Debug.Log("moving to destinationPos4");

            //move camera to cameraSettingsMenuPos.transform.position
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, destinationPos4.transform.position, cameraMovementSpeed);
            //rotate cam to match the rotation of cameraSettingsMenuPos.transform.position
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, destinationPos4.transform.rotation, cameraMovementSpeed);


            if (cam.transform.position == fadeZone4.transform.position)
            {
                //call a function to fade the screen
                FadeIn();
            }
            //show settings canvas when in position
            if (cam.transform.position == destinationPos4.transform.position)
            {
                //set starting position+rotation
                cam.transform.position = defaultPos5.transform.position;
                cam.transform.rotation = defaultPos5.transform.rotation;
                
                FadeOut();

                Debug.Log("at destinationPos4");
                pathCounter = 4;
            }
        }
        if (pathCounter == 4)
        {
            //call a function to unfade the screne
            //FadeOut();

            Debug.Log("moving to destinationPos5");

            //move camera to cameraSettingsMenuPos.transform.position
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, destinationPos5.transform.position, cameraMovementSpeed);
            //rotate cam to match the rotation of cameraSettingsMenuPos.transform.position
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, destinationPos5.transform.rotation, cameraMovementSpeed);

            if (cam.transform.position == fadeZone5.transform.position)
            {
                //call a function to fade the screen
                FadeIn();
            }
            //show settings canvas when in position
            if (cam.transform.position == destinationPos5.transform.position)
            {
                //set starting position+rotation
                cam.transform.position = defaultPos1.transform.position;
                cam.transform.rotation = defaultPos1.transform.rotation;

                FadeOut();

                Debug.Log("at destinationPos5");
                pathCounter = 0; //set to 0 to loop it
            }
        }
    }


    //for fading camera effect between paths
    public void FadeIn()
    {
        StartCoroutine(FadeImage(0f, 1f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeImage(1f, 0f));
    }

    private IEnumerator FadeImage(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        Color color = targetImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            targetImage.color = color;
            yield return null;
        }

        color.a = endAlpha; // Ensure the final alpha value is exact
        targetImage.color = color;
    }

}
