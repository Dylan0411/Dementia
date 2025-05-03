using UnityEngine;

public class GridController : MonoBehaviour
{
    // https://discussions.unity.com/t/3d-grid-movement/227008/2 used as reference

    GameObject Player;

    bool waitForInputs = false;
    bool vertActive = false;
    bool horiActive = false;

    public float moveVal = 1;
    float negativeMoveVal;
    float movePick;

    Vector3 movement;
    Vector3 desiredPos;
    Vector3 smoothPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        negativeMoveVal = (-1 * moveVal);

        //Code expects player's children to be the floating collision boxes.
        //To make it easier to change later, the code specifies index (0-3).
        //Conversely, this means the colliders must be in the 0-3 position.
        GameObject leftCollider = Player.transform.GetChild(0).gameObject;
        GameObject downCollider = Player.transform.GetChild(1).gameObject;
        GameObject rightCollider = Player.transform.GetChild(2).gameObject;
        GameObject upCollider = Player.transform.GetChild(3).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (waitForInputs == false)
        {
            //Tries to work out if it's doing vert or hori
            if ((Input.GetAxis("Vertical") == 1) || (Input.GetAxis("Vertical") == -1)) { vertActive = true; }
            if ((Input.GetAxis("Horizontal") == 1) || (Input.GetAxis("Horizontal") == -1)) { horiActive = true; }

            //If it's vert, not hori
            if (vertActive == true && horiActive == false) {
                if (Input.GetAxis("Vertical") == 1) { movePick = moveVal; }
                else { movePick = negativeMoveVal; }
                movement = new Vector3(0.0f, 0.0f, movePick);
            }
            //If it's hori, not vert
            if (vertActive == false && horiActive == true) {
                if (Input.GetAxis("Horizontal") == 1) { movePick = moveVal; }
                else { movePick = negativeMoveVal; }
                movement = new Vector3(movePick, 0.0f, 0.0f);
            }
            //If both are being held down
            if (vertActive == true && horiActive == true) {
                //Prioritise vert movement
                if (Input.GetAxis("Vertical") == 1) { movePick = moveVal; }
                else { movePick = negativeMoveVal; }
                movement = new Vector3(0.0f, 0.0f, movePick);
            }

            waitForInputs = true;
            vertActive = false; horiActive = false;
            desiredPos = Player.transform.position + movement;
        }

        smoothPos = Vector3.Lerp(Player.transform.position, desiredPos, 0.1f);

        Player.transform.position = smoothPos;
        if (Player.transform.position == desiredPos) {
            movement = new Vector3(0.0f, 0.0f, 0.0f);
            waitForInputs = false;
        }
    }
}
