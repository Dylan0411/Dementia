using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // https://discussions.unity.com/t/3d-grid-movement/227008/2 used as reference

    GameObject Self;

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
        Self = this.GameObject();
        negativeMoveVal = (-1 * moveVal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
