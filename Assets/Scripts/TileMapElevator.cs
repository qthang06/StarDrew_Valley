using UnityEngine;

public class TileMapElevator : MonoBehaviour
{
    public Collider2D[] moutainCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (Collider2D moutain in moutainCollider)
        {
            moutain.enabled = false;
        }
    }
}
