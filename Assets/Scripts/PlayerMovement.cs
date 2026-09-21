using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));
        //Debug.Log($"Horizontal: {horizontal}, Vertical: {vertical}");

        rb.linearVelocity = new Vector2(horizontal, vertical) * moveSpeed;
    }
}
