using UnityEngine;

public class MazeController : MonoBehaviour
{
    public float tiltSpeed = 5f;

    public GameObject player;
    public GameObject tableCamera;
    public GameObject mainPlayerCamera;
    public GameObject interactableMaze;
    public GameObject fakeMaze;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float tiltX = Input.GetAxis("Vertical") * tiltSpeed * Time.deltaTime;
        float tiltZ = Input.GetAxis("Horizontal") * tiltSpeed * Time.deltaTime;

        //Tilts the maze
        transform.Rotate(tiltX, 0f, -tiltZ);

        if (Input.GetKeyDown(KeyCode.F) || PlayerPrefs.GetInt("puzzle6Status") == 1)
        {
            //Switch cameras back to the player's view
            tableCamera.SetActive(false);
            mainPlayerCamera.SetActive(true);

            //Re-enable player controls
            player.SetActive(true);

            //Mark the table as not being used
            puzzle6Starter.usingTable = false;

            //show the correct maze
            fakeMaze.SetActive(true);
            interactableMaze.SetActive(false);
        }
    }
}
