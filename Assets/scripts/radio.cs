using UnityEngine;

public class radio : MonoBehaviour
{

    public GameObject interactWithRadioText;

    public GameObject radioAudio;

    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize UI and state
        interactWithRadioText.SetActive(false);

        //hide the ui showing the image to the player
        radioAudio.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue); // TEMP - DELETE THIS

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            if (hit.collider.gameObject.tag == "radio")//if player is looking at the photo frame..
            {
                //Show interaction hint
                interactWithRadioText.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F)) //Toggle light
                {
                    interactWithRadioText.SetActive(false);

                    // toggle the active state of the light
                    radioAudio.SetActive(!radioAudio.activeSelf);
                }
            }
            else
            {
                //Hide interaction hint
                interactWithRadioText.SetActive(false);

            }
        }
    }
}

