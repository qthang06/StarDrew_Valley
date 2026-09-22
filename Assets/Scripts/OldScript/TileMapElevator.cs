using UnityEngine;

public class TileMapElevator : MonoBehaviour
{
    public Collider2D[] moutainCollider;
    public Collider2D[] exitBoundries;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D moutain in moutainCollider)
            {
                moutain.enabled = false;
            }
            foreach (Collider2D bound in exitBoundries)
            {
                bound.enabled = true;
            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        }
    }
}
