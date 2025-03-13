using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;

public class photoInterface : MonoBehaviour
{
    public GameObject interactWithTableText;
    public GameObject interactableCrosshair;
    public GameObject itemDestination;

    public GameObject photoCanvas;

    bool viewingImage;

    public GameObject player;

    public GameObject pictureObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize UI and state
        interactWithTableText.SetActive(false);
        itemDestination.SetActive(false);
        viewingImage = false;

        photoCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("viewingImage = " + viewingImage);

        if (!viewingImage) // Only show interaction hint when not viewing the image
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue); // TEMP - DELETE THIS

            if (Physics.Raycast(ray, out hit, 2.5f))
            {
                if (hit.collider.gameObject.tag == "puzzle4Picture")
                {
                    // Show interaction hint
                    interactWithTableText.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.F)) // Open menu logic
                    {
                        Debug.Log("started F - OPEN MENU");

                        interactWithTableText.SetActive(false);
                        interactableCrosshair.SetActive(false);

                        photoCanvas.SetActive(true); // Shows the image to the player

                        // PAUSE GAME
                        player.GetComponent<playerLook>().enabled = false; // Disable player look controls
                        player.GetComponent<PickupItem>().enabled = false; // Disable raycast controls
                        Time.timeScale = 0f; // Pause time

                        viewingImage = true; // Update state

                        Debug.Log("finished F - OPEN MENU");
                    }
                }
                else
                {
                    // Hide interaction hint
                    interactWithTableText.SetActive(false);
                }
            }
            else
            {
                // Hide interaction hint
                interactWithTableText.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F)) // Close menu logic
            {
                Debug.Log("started F - CLOSE MENU");

                photoCanvas.SetActive(false); // Hides the image to the player
                itemDestination.SetActive(true); // Adds the destination

                // UNPAUSE GAME
                player.GetComponent<playerLook>().enabled = true; // Enable player look controls
                player.GetComponent<PickupItem>().enabled = true; // Enable raycast controls
                Time.timeScale = 1f; // Resume time

                viewingImage = false; // Update state

                Debug.Log("finished F - CLOSE MENU");
            }
        }

        // If the player has completed puzzle 4, stop them from viewing the image
        int completedPuzzle4 = PlayerPrefs.GetInt("puzzle4Status", 0);
        if (completedPuzzle4 == 1)
        {
            pictureObject.tag = "Untagged"; // Prevent further interactions
        }
    }
}
