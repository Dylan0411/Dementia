using UnityEngine;
using UnityEngine.Tilemaps;

public class blueCubeBehaviour : MonoBehaviour
{
    private GridController grid;
    [SerializeField] private GameObject blueCollider;
    [SerializeField] private GameObject closedBridge;
    [SerializeField] private GameObject raisedBridge;

    public int activeInterval = -1;
    private bool isActive = false;
    private int bridgeDelay = -1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GetComponentInParent<GridController>();
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        //Lower Bridge
        if (bridgeDelay == grid.GetTime())
        {
            raisedBridge.SetActive(false);
            closedBridge.SetActive(true);
        }
        
        if ((grid.GetTime() != 0) && (grid.GetTime() % activeInterval == 0))
        {
            isActive = true;
            Activate();
        }
        else if (isActive == true)
        {
            Deactivate();
            bridgeDelay = grid.GetTime(); bridgeDelay++;
            isActive = false;
        }

    }

    void Activate()
    {
        blueCollider.SetActive(true);

        //Raise Bridge
        closedBridge.SetActive(false);
        raisedBridge.SetActive(true);
    }

    void Deactivate()
    {
        blueCollider.SetActive(false);
    }
}
