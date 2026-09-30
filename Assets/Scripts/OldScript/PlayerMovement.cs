using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
public class PlayerMovement : MonoBehaviour
{
    public PlayerMovementState moveState;
    public float moveSpeed = 5f;
    private int isFacingRight = 1;

    public Rigidbody2D rb;
    public Animator anim;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        rb.linearVelocity = new Vector2(horizontal, vertical) * moveSpeed;
    }

    void Flip()
    {
        isFacingRight *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
