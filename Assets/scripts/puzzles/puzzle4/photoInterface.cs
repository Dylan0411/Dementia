using UnityEngine;

public class photoInterface : MonoBehaviour
{
    public GameObject interactWithTableText;
    public GameObject interactableCrosshair;
    public GameObject itemDestination;

    public GameObject photoCanvas;

    public static bool viewingImage;

    public GameObject player;

    public GameObject pictureObject;

    float savedFov;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize UI and state
        interactWithTableText.SetActive(false);
        itemDestination.SetActive(false);
        viewingImage = false;

        //hide the ui showing the image to the player
        photoCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!viewingImage) //Only show the interaction hint when not viewing the image
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue); // TEMP - DELETE THIS

            if (Physics.Raycast(ray, out hit, 2.5f))
            {
                if (hit.collider.gameObject.tag == "puzzle4Picture")//if player is looking at the photo frame..
                {
                    //Show interaction hint
                    interactWithTableText.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F)) // Open menu logic
                    {
                        //save existing fov
                        savedFov = PlayerPrefs.GetFloat("camFOV");
                        //Change fov to 30
                        PlayerPrefs.SetFloat("camFOV", 30);

                        interactWithTableText.SetActive(false);
                        interactableCrosshair.SetActive(false);

                        photoCanvas.SetActive(true); // Shows the image to the player

                        //disable some player scripts+pause time
                        player.GetComponent<playerLook>().enabled = false; // Disable player look controls
                        player.GetComponent<PickupItem>().enabled = false; // Disable raycast controls

                        Invoke("shortDelay", 0.1f);

                        viewingImage = true; //Update state
                    }
                }
                else
                {
                    //Hide interaction hint
                    interactWithTableText.SetActive(false);
                }
            }
            else
            {
                //Hide interaction hint
                interactWithTableText.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F)) // Close menu logic
            {
                //then after reapply the old saved fov
                PlayerPrefs.SetFloat("camFOV", savedFov);


                photoCanvas.SetActive(false); // Hides the image to the player
                itemDestination.SetActive(true); // Adds the destination

                //re-enable the player scripts + un-pause time
                player.GetComponent<playerLook>().enabled = true; // Enable player look controls
                player.GetComponent<PickupItem>().enabled = true; // Enable raycast controls
                Time.timeScale = 1f; // Resume time

                viewingImage = false; // Update state
            }
        }

        // If the player has completed puzzle 4, stop them from viewing the image
        int completedPuzzle4 = PlayerPrefs.GetInt("puzzle4Status", 0);
        if (completedPuzzle4 == 1)
        {
            pictureObject.tag = "Untagged"; //Prevent further interactions
        }
    }

    void shortDelay()
    {
        Time.timeScale = 0f; //Pause time
    }
}
