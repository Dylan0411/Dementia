using UnityEngine;

public class brokenItem : MonoBehaviour
{
    public GameObject player;
    public GameObject tableCamera;
    public GameObject mainPlayerCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D)) //exit table
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


        //interacting with broken vase code here





    }
}
