using UnityEngine;

public class lightSwitch : MonoBehaviour
{

    public GameObject interactWithLightText;


    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;
    public GameObject Light5;
    public GameObject Light6;
    public GameObject Light7;

    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize UI and state
        interactWithLightText.SetActive(false);

        Light1.SetActive(true);
        Light2.SetActive(true);
        Light3.SetActive(true);
        Light4.SetActive(true);
        Light5.SetActive(true);
        Light6.SetActive(true);
        Light7.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue); // TEMP - DELETE THIS

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            if (hit.collider.gameObject.tag == "lightSwitch1")//if player is looking at the photo frame..
            {
                //Show interaction hint
                interactWithLightText.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F)) //Toggle light
                {
                    interactWithLightText.SetActive(false);

                    // toggle the active state of the light
                    Light1.SetActive(!Light1.activeSelf);
                }
            }
            else if (hit.collider.gameObject.tag == "lightSwitch2")//if player is looking at the photo frame..
            {
                //Show interaction hint
                interactWithLightText.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F)) //Toggle light
                {
                    interactWithLightText.SetActive(false);

                    // toggle the active state of the light
                    Light2.SetActive(!Light2.activeSelf);
                    Light3.SetActive(!Light3.activeSelf);
                }
            }
            else if (hit.collider.gameObject.tag == "lightSwitch3")//if player is looking at the photo frame..
            {
                //Show interaction hint
                interactWithLightText.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F)) //Toggle light
                {
                    interactWithLightText.SetActive(false);

                    // toggle the active state of the light
                    Light4.SetActive(!Light4.activeSelf);
                    Light5.SetActive(!Light5.activeSelf);

                }
            }
            else if (hit.collider.gameObject.tag == "lightSwitch4")//if player is looking at the photo frame..
            {
                //Show interaction hint
                interactWithLightText.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F)) //Toggle light
                {
                    interactWithLightText.SetActive(false);

                    // toggle the active state of the light
                    Light6.SetActive(!Light6.activeSelf);
                }
            }
            else if (hit.collider.gameObject.tag == "lightSwitch5")//if player is looking at the photo frame..
            {
                //Show interaction hint
                interactWithLightText.SetActive(true);


                if (Input.GetKeyDown(KeyCode.F)) //Toggle light
                {
                    interactWithLightText.SetActive(false);

                    // toggle the active state of the light
                    Light7.SetActive(!Light7.activeSelf);
                }
            }
            else
            {
                //Hide interaction hint
                interactWithLightText.SetActive(false);

            }
        }
    }
}
