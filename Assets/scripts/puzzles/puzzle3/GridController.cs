using UnityEngine;

public class GridController : MonoBehaviour
{
    // https://discussions.unity.com/t/3d-grid-movement/227008/2 used as reference

    GameObject Player;

    public int puzzleTimer;
    public int currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 0;
    }

    private void EndGame()
    {
        //add end game code
    }

    public void AdvanceTime()
    {
        currentTime += 1;
        if (puzzleTimer <= currentTime)
        {
            EndGame();
        }
    }

    public int GetTime()
    {
        return currentTime;
    }
}