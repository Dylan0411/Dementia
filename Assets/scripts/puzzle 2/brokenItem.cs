using UnityEngine;

public class brokenItem : MonoBehaviour
{
    public GameObject player;
    public GameObject tableCamera;
    public GameObject mainPlayerCamera;

    // Update is called once per frame
    void Update()
    {
        if (tableInterface.usingTable == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) //exit table
            {
                //lock and hide the cursor
                Cursor.lockState = CursorLockMode.Locked;//let the player move the cursor
                Cursor.visible = false; //hide cursor

                //switch cameras
                tableCamera.SetActive(false);
                mainPlayerCamera.SetActive(true);

                //bring back the players body
                player.SetActive(true);

                tableInterface.usingTable = false;  //mark the table as not being used (allows the player to walk around etc)
            }

            //interacting with broken teapot code here

            Ray ray;
            RaycastHit hit;

            Camera tableCam = tableCamera.GetComponent<Camera>();
            ray = tableCam.ScreenPointToRay(Input.mousePosition); // fire ray from camera constantly

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

            if (Physics.Raycast(ray, out hit, 2.5f)) //shoot ray
            {
                if (hit.collider.gameObject.tag == "teapotSpout")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotSpout");
                    }
                }
                if (hit.collider.gameObject.tag == "teapotHandle1")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotHandle1");
                    }
                }
                if (hit.collider.gameObject.tag == "teapotHandle2")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotHandle2");
                    }
                }
                if (hit.collider.gameObject.tag == "teapotLid1")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotLid1");
                    }
                }
                if (hit.collider.gameObject.tag == "teapotLid2")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotLid2");
                    }
                }
                if (hit.collider.gameObject.tag == "teapotBase")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotBase");
                    }
                }
                if (hit.collider.gameObject.tag == "teapotMainBody")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotMainBody");
                    }
                }


            }
        }

    }
}
