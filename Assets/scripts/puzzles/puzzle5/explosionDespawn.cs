using UnityEngine;

public class explosionDespawn : MonoBehaviour
{


    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        Explosion.SetActive(true);
        Invoke("despawn", 2f);
    }
    void despawn()
    {
        Destroy(gameObject);
    }
}
