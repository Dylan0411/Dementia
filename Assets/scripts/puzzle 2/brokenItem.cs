using UnityEngine;

public class brokenItem : MonoBehaviour
{
    public GameObject player;
    public GameObject tableCamera;
    public GameObject mainPlayerCamera;

    public GameObject ghostTeapot;
    //
    public GameObject teapotSpout;
    public GameObject teapotHandle1;
    public GameObject teapotHandle2;
    public GameObject teapotLid1;
    public GameObject teapotLid2;
    public GameObject teapotBase;
    public GameObject teapotMainBody;

    int rotationSpeed = 100;

    bool rotateTeapotLeft;
    bool rotateTeapotRight;

    private Vector3 offset;
    private bool isFollowingMouse = false;

    GameObject selectedObject;



    void Start()
    {
        rotateTeapotLeft = false;
        rotateTeapotRight = false;
    }

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
                        //make theobject follow the mouse position
                        isFollowingMouse = true;
                        selectedObject = teapotSpout;
                    }
                }
                if (hit.collider.gameObject.tag == "teapotHandle1")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotHandle1");
                        //make theobject follow the mouse position
                        isFollowingMouse = true;
                        selectedObject = teapotHandle1;
                    }
                }
                if (hit.collider.gameObject.tag == "teapotHandle2")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotHandle2");
                        //make theobject follow the mouse position
                        isFollowingMouse = true;
                        selectedObject = teapotHandle2;
                    }
                }
                if (hit.collider.gameObject.tag == "teapotLid1")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotLid1");
                        //make theobject follow the mouse position
                        isFollowingMouse = true;
                        selectedObject = teapotLid1;
                    }
                }
                if (hit.collider.gameObject.tag == "teapotLid2")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotLid2");
                        //make theobject follow the mouse position
                        isFollowingMouse = true;
                        selectedObject = teapotLid2;
                    }
                }
                if (hit.collider.gameObject.tag == "teapotBase")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotBase");
                        //make theobject follow the mouse position
                        isFollowingMouse = true;
                        selectedObject = teapotBase;
                    }
                }
                if (hit.collider.gameObject.tag == "teapotMainBody")//if the mouse is hovering over an item
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log("teapotMainBody");

                        //make theobject follow the mouse position
                        isFollowingMouse = true;
                        selectedObject = teapotMainBody;
                    }
                }
            }

            /////
            if (isFollowingMouse)
            {

                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    //stop making the teapotMainBody object follow the mouse position <<< IMPLEMENT THIS
                    isFollowingMouse = false;
                }

                // Update teapot's position to follow the mouse
                RaycastHit hitMousePosition;
                if (Physics.Raycast(ray, out hitMousePosition, 100f))
                {
                    // Only update the X and Z positions, keep Y the same as original
                    Vector3 newPosition = hitMousePosition.point;// + offset;
                    newPosition.y = selectedObject.transform.position.y; // Preserve the Y position

                    selectedObject.transform.position = newPosition;
                }
            }









            if (rotateTeapotRight == true)
            {
                ghostTeapot.transform.Rotate(-Vector3.forward, rotationSpeed * Time.deltaTime);
                //
                teapotSpout.transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
                teapotHandle1.transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
                teapotHandle2.transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
                teapotLid1.transform.Rotate(new Vector3(0, 0, -1), rotationSpeed * Time.deltaTime);
                //teapotLid2.transform.Rotate(new Vector3(0, 0, -1), rotationSpeed * Time.deltaTime);
                teapotBase.transform.Rotate(new Vector3(0, 0, -1), rotationSpeed * Time.deltaTime);
                teapotMainBody.transform.Rotate(new Vector3(0, 0, -1), rotationSpeed * Time.deltaTime);


            }
            if (rotateTeapotLeft == true)
            {
                ghostTeapot.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                //
                teapotSpout.transform.Rotate(new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);
                teapotHandle1.transform.Rotate(new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);
                teapotHandle2.transform.Rotate(new Vector3(0, -1, 0), rotationSpeed * Time.deltaTime);
                teapotLid1.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
                //teapotLid2.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
                teapotBase.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
                teapotMainBody.transform.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);

            }
        }

    }



    public void rotateRightSTART()
    {
        //rotat teapot to the right
        rotateTeapotRight = true;
    }
    public void rotateRightSTOP()
    {
        //rotat teapot to the right
        rotateTeapotRight = false;
    }

    public void rotateLeftSTART()
    {
        //rotat teapot to the right
        rotateTeapotLeft = true;
    }
    public void rotateLeftSTOP()
    {
        //rotat teapot to the right
        rotateTeapotLeft = false;
    }









}
