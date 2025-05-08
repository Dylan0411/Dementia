using UnityEngine;

public class water : MonoBehaviour
{

    public GameObject interactWithWaterText;

    public GameObject water1;
    public GameObject water2;
    public GameObject water3;

    public GameObject player;

    public AudioSource interactionSFX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize UI and state
        interactWithWaterText.SetActive(false);

        //hide the ui showing the image to the player
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

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            if (hit.collider.gameObject.tag == "water1")//if player is looking at the photo frame..
            {
                //Show interaction hint
                interactWithWaterText.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F)) //Toggle light
                {
                    interactionSFX.Play();

                    interactWithWaterText.SetActive(false);

                    // toggle the active state of the light
                    water1.SetActive(!water1.activeSelf);
                }
            }
            else if (hit.collider.gameObject.tag == "water2")//if player is looking at the photo frame..
            {
                //Show interaction hint
                interactWithWaterText.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F)) //Toggle light
                {
                    interactionSFX.Play();

                    interactWithWaterText.SetActive(false);

                    // toggle the active state of the light
                    water2.SetActive(!water2.activeSelf);
                }
            }
            else if (hit.collider.gameObject.tag == "water3")//if player is looking at the photo frame..
            {
                //Show interaction hint
                interactWithWaterText.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F)) //Toggle light
                {
                    interactionSFX.Play();

                    interactWithWaterText.SetActive(false);

                    // toggle the active state of the light
                    water3.SetActive(!water3.activeSelf);

                }
            }
            else
            {
                //Hide interaction hint
                interactWithWaterText.SetActive(false);

            }
        }
    }
}
