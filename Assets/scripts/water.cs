using UnityEngine;

public class water : MonoBehaviour
{
    public GameObject interactWithWaterText1;
    public GameObject interactWithWaterText2;
    public GameObject interactWithWaterText3;

    public GameObject water1;
    public GameObject water2;
    public GameObject water3;

    public GameObject player;

    public AudioSource interactionSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize UI and state
        interactWithWaterText1.SetActive(false);
        interactWithWaterText2.SetActive(false);
        interactWithWaterText3.SetActive(false);

        // Hide the UI showing the image to the player
        water1.SetActive(false);
        water2.SetActive(false);
        water3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue); // TEMP - DELETE THIS

        bool lookingAtWater = false; // Track if player is looking at any water object

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            if (hit.collider.CompareTag("water1")) // If player is looking at water1
            {
                interactWithWaterText1.SetActive(true);
                lookingAtWater = true;

                if (Input.GetKeyDown(KeyCode.F)) // Toggle water1 state
                {
                    interactionSFX.Play();
                    interactWithWaterText1.SetActive(false);
                    water1.SetActive(!water1.activeSelf);
                }
            }

            if (hit.collider.CompareTag("water2")) // If player is looking at water2
            {
                interactWithWaterText2.SetActive(true);
                lookingAtWater = true;

                if (Input.GetKeyDown(KeyCode.F)) // Toggle water2 state
                {
                    interactionSFX.Play();
                    interactWithWaterText2.SetActive(false);
                    water2.SetActive(!water2.activeSelf);
                }
            }

            if (hit.collider.CompareTag("water3")) // If player is looking at water3
            {
                interactWithWaterText3.SetActive(true);
                lookingAtWater = true;
                Debug.Log("water3 active");

                if (Input.GetKeyDown(KeyCode.F)) // Toggle water3 state
                {
                    interactionSFX.Play();
                    interactWithWaterText3.SetActive(false);
                    water3.SetActive(!water3.activeSelf);
                }
            }
        }

        // Hide all interaction texts only when the player is NOT looking at any water object
        if (!lookingAtWater)
        {
            interactWithWaterText1.SetActive(false);
            interactWithWaterText2.SetActive(false);
            interactWithWaterText3.SetActive(false);
            Debug.Log("water3 inactive"); // Debug log for when water3 is inactive
        }
    }
}