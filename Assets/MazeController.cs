using UnityEngine;

public class MazeController : MonoBehaviour
{
    public float tiltSpeed = 5f;
    
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
    }
}
