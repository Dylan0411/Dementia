using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // https://discussions.unity.com/t/3d-grid-movement/227008/2 used as reference

    GameObject self;
    private GridController grid;

    public PlayerColliderScript leftCollider;
    public PlayerColliderScript downCollider;
    public PlayerColliderScript rightCollider;
    public PlayerColliderScript upCollider;

    bool waitForInputs = false;
    bool vertActive = false;
    bool horiActive = false;

    public float moveVal = 1;
    float negativeMoveVal;
    float movePick;

    Vector3 movement;
    Vector3 desiredPos;
    Vector3 smoothPos;

    // ** Audio Variables **
    private AudioSource audioSource;

    public AudioClip[] leftSounds;      // RL1, RL2, RL3
    public AudioClip[] rightSounds;     // LR1, LR2, LR3
    public AudioClip[] forwardSounds;   // FB1, FB2, FB3
    public AudioClip[] backwardSounds;  // FB1, FB2, FB3

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        self = this.GameObject();
        grid = GetComponentInParent<GridController>();
        negativeMoveVal = (-1 * moveVal);

        // init audio source
        audioSource = GetComponent<AudioSource>();
    }

    void PlayRandomSound(AudioClip[] soundArray)
    {
        if (soundArray.Length > 0)
        {
            AudioClip clip = soundArray[Random.Range(0, soundArray.Length)];
            audioSource.PlayOneShot(clip);
        }
    }

    float VertCheck()
    {
        //Move up
        if (Input.GetAxis("Vertical") == 1) {
            if (upCollider.IsColliding()) {
                PlayRandomSound(forwardSounds);  return moveVal; } //Means the player can move
        }

        //Move down
        else {
            if (downCollider.IsColliding()) { PlayRandomSound(backwardSounds); return negativeMoveVal; }
        }

        return 0.0f;
    }

    float HoriCheck()
    {
        //Move right
        if (Input.GetAxis("Horizontal") == 1) {
            if (rightCollider.IsColliding()) { PlayRandomSound(rightSounds); return moveVal; } //same as above
        }

        //Move left
        else {
            if (leftCollider.IsColliding()) { PlayRandomSound(leftSounds); return negativeMoveVal; } //same as above
        }

        return 0.0f;
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
            if (vertActive == true && horiActive == false)
            {
                movePick = VertCheck();
                movement = new Vector3(0.0f, 0.0f, movePick);
            }
            //If it's hori, not vert
            if (vertActive == false && horiActive == true)
            {
                movePick = HoriCheck();
                movement = new Vector3(movePick, 0.0f, 0.0f);
            }
            //If both are being held down
            if (vertActive == true && horiActive == true)
            {
                //Prioritise vert movement
                movePick = VertCheck();
                if (movePick == 0.0f)
                { //If vert movement wasn't valid - allows for hori movement instead
                    movePick = HoriCheck();
                    movement = new Vector3(movePick, 0.0f, 0.0f);
                }
                else { movement = new Vector3(0.0f, 0.0f, movePick); }
            }

            //Advance time
            if (movePick != 0.0f) { grid.AdvanceTime(); }
            movePick = 0.0f;

            waitForInputs = true;
            vertActive = false; horiActive = false;
            desiredPos = self.transform.localPosition + movement;
        }

        smoothPos = Vector3.Lerp(self.transform.localPosition, desiredPos, Time.deltaTime * 10);

        self.transform.localPosition = smoothPos;
        if (self.transform.localPosition == desiredPos)
        {
            movement = new Vector3(0.0f, 0.0f, 0.0f);
            waitForInputs = false;
        }
    }
}
