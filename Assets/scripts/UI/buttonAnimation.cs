using UnityEngine;

public class buttonAnimation : MonoBehaviour
{
    public void animationSTART()
    {
        transform.localScale = new Vector2(1.25f, 1.25f); //make button slightly bigger
    }
    public void animationEND()
    {
        transform.localScale = new Vector2(1f, 1f); //put button back to original size
    }
}
