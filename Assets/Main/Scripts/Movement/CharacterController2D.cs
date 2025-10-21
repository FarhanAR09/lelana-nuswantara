using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class CharacterController2D : MonoBehaviour
{
    [Header("Settings")]
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    [HideInInspector] public bool isGrounded { get; private set; }
    [HideInInspector] public Vector2 groundNormal { get; private set; } = Vector2.up;

    [HideInInspector]
    public Rigidbody2D rb;
    private Collider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    void FixedUpdate()
    {
        CheckGrounded();
    }

    public void Move(Vector2 position)
    {
        rb.MovePosition(position);
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    private void CheckGrounded()
    {
        Vector2 origin = col.bounds.center;
        float extraHeight = groundCheckDistance;

        RaycastHit2D hit = Physics2D.BoxCast(origin, col.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);

        if (hit.collider != null)
        {
            isGrounded = true;
            groundNormal = hit.normal;
        }
        else
        {
            isGrounded = false;
            groundNormal = Vector2.up;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (col == null) return;
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireCube(col.bounds.center + Vector3.down * groundCheckDistance / 2f, col.bounds.size);

        // visualize normal
        if (isGrounded)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(col.bounds.center, col.bounds.center + (Vector3)groundNormal * 0.5f);
        }
    }
}
