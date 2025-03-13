using UnityEngine;

public class brokenItem : MonoBehaviour
{
    public GameObject player;
    public GameObject tableCamera;
    public GameObject mainPlayerCamera;

    public GameObject ghostTeapot;
    public GameObject fragments;
    
    public GameObject teapotSpout;
    public GameObject teapotHandle1;
    public GameObject teapotHandle2;
    public GameObject teapotLid1;
    public GameObject teapotLid2;
    public GameObject teapotBase;
    public GameObject teapotMainBody;

    public GameObject teapotSpoutDefaultPos;
    public GameObject teapotHandle1DefaultPos;
    public GameObject teapotHandle2DefaultPos;
    public GameObject teapotLid1DefaultPos;
    public GameObject teapotLid2DefaultPos;
    public GameObject teapotBaseDefaultPos;
    public GameObject teapotMainBodyDefaultPos;

    public GameObject ghostTeapotSpout;
    public GameObject ghostTeapotHandle1;
    public GameObject ghostTeapotHandle2;
    public GameObject ghostTeapotLid1;
    public GameObject ghostTeapotLid2;
    public GameObject ghostTeapotBase;
    public GameObject ghostTeapotMainBody;

    int rotationSpeed = 100; //<<<<<<<<<< feel free to change :)

    private Vector3 offset;

    public static bool isFollowingMouse;

    GameObject selectedObject;

    public static int correctPieces;

    public GameObject cylinder;

    LayerMask ghostTeapotLayerMask;

    void Start()
    {
        isFollowingMouse = false;

        correctPieces = 0;

        PlayerPrefs.SetInt("puzzle2Status", 0);//<<<<<<<<<<<<<<<<<<<<DELETE THIS IF USING SAVE DATA IN FUTURE

        ghostTeapotLayerMask = LayerMask.NameToLayer("ghostTeapot");
    }

    // Update is called once per frame
    void Update()
    {
        if (correctPieces == 7) //if all the fragments are in the right place
        {
            Debug.Log("uhhhhh");
            PlayerPrefs.SetInt("puzzle2Status", 1); //mark as complete
        }

        if (tableInterface.usingTable == true)
        {
            //exit table
            if (Input.GetKeyDown(KeyCode.F) || PlayerPrefs.GetInt("puzzle2Status") == 1) //if the player exits or if the puzzle is complete
            {
                //hide the loose fragments on the table
                fragments.SetActive(false);

                //lock and hide the cursor
                Cursor.lockState = CursorLockMode.Locked;

                //switch cameras
                tableCamera.SetActive(false);
                mainPlayerCamera.SetActive(true);

                //bring back the players body
                player.SetActive(true);

                //mark the table as not being used (allows the player to walk around etc)
                tableInterface.usingTable = false;

                //set rotation of teapot to default
                ghostTeapot.transform.rotation = Quaternion.Euler(90, 90, 0);
            }

            //interacting with broken teapot code here
            Ray ray;
            RaycastHit hit;

            // fire ray from camera constantly
            Camera tableCam = tableCamera.GetComponent<Camera>();
            ray = tableCam.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red); //TEMP - DELETE THIS

            //if the game isnt paused
            if (Time.timeScale > 0)
            {
                Cursor.lockState = CursorLockMode.None;//let the player move the cursor

                if (Physics.Raycast(ray, out hit, 2.5f, ghostTeapotLayerMask)) //shoot ray (let the player shoot through the ghost teapot, ignoring its existence
                {
                    //make beam of light stay on the cursors position
                    Vector3 newPosition = hit.point;
                    newPosition.y = cylinder.transform.position.y; //Preserve the Y position (dont change the height)
                    cylinder.transform.position = newPosition;

                    //when the player attempts to select an item
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (hit.collider.gameObject.tag == "teapotSpout" || hit.collider.gameObject.tag == "teapotHandle1" || hit.collider.gameObject.tag == "teapotHandle2" || hit.collider.gameObject.tag == "teapotLid1" || hit.collider.gameObject.tag == "teapotLid2" || hit.collider.gameObject.tag == "teapotBase" || hit.collider.gameObject.tag == "teapotMainBody")//if the mouse is hovering over an item
                        {
                            selectedObject = hit.collider.gameObject; //select the correct fragment
                            isFollowingMouse = true; //toggle the object to follow the mouse position
                            offset = selectedObject.transform.position - hit.point; //calculate the offset (prevents the fragent from jumping around when its selected)
                        }
                    }
                }
            }

            //if a fragment is following the cursor
            if (isFollowingMouse == true)
            {
                if (Input.GetKeyUp(KeyCode.Mouse0)) //if player lets go of left click while holding a fragment..
                {
                    //stop making the fragment follow the mouse position
                    isFollowingMouse = false;
                }

                //if game isnt paused then fire ray
                RaycastHit hitMousePosition;
                if (Time.timeScale > 0)
                {
                    if (Physics.Raycast(ray, out hitMousePosition, 100f))
                    {
                        //move the object with the position of the cursor
                        Vector3 newPosition = hitMousePosition.point + offset; //add the offset to stop the selected piece jumping around when being selected
                        newPosition.y = selectedObject.transform.position.y; // Preserve the Y position (dont change the height)
                        selectedObject.transform.position = newPosition;
                    }
                }
            }
            //if a fragment isnt following the cursor
            else
            {
                //if an object has been selected and has a unique tag, return it to the correct location based on what the tag is
                if (selectedObject != null && selectedObject.tag != "Untagged")
                {
                    if (selectedObject.tag == "teapotSpout")
                    {
                        selectedObject.transform.position = teapotSpoutDefaultPos.transform.position;
                    }
                    if (selectedObject.tag == "teapotHandle1")
                    {
                        selectedObject.transform.position = teapotHandle1DefaultPos.transform.position;
                    }
                    if (selectedObject.tag == "teapotHandle2")
                    {
                        selectedObject.transform.position = teapotHandle2DefaultPos.transform.position;
                    }
                    if (selectedObject.tag == "teapotLid1")
                    {
                        selectedObject.transform.position = teapotLid1DefaultPos.transform.position;
                    }
                    if (selectedObject.tag == "teapotLid2")
                    {
                        selectedObject.transform.position = teapotLid2DefaultPos.transform.position;
                    }
                    if (selectedObject.tag == "teapotBase")
                    {
                        selectedObject.transform.position = teapotBaseDefaultPos.transform.position;
                    }
                    if (selectedObject.tag == "teapotMainBody")
                    {
                        selectedObject.transform.position = teapotMainBodyDefaultPos.transform.position;
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D)) //rotate the ghost teapot clockwise
        {
            ghostTeapot.transform.Rotate(-Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) //rotate the ghost teapot anti-clockwise
        {
            ghostTeapot.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}