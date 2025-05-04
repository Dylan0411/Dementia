using UnityEngine;

public class blueCubeBehaviour : MonoBehaviour
{
    private GridController grid;
    [SerializeField] private GameObject blueCollider;

    public int activeInterval = -1;
    private bool isActive = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = GetComponentInParent<GridController>();
        Deactivate();
    }

    // Update is called once per frame
    void Update()
    {
        if (grid.GetTime() == activeInterval)
        {
            isActive = true;
            Activate();
        }
        else if (isActive == true)
        {
            Deactivate();
        }
    }

    void Activate()
    {
        blueCollider.SetActive(true);
    }

    void Deactivate()
    {
        blueCollider.SetActive(false);
    }
}
