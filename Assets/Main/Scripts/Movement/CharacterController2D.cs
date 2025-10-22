using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class CharacterController2D : MonoBehaviour
{
    [Header("Ground Settings")]
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;
    [Tooltip("Maximum angle (in degrees) that counts as walkable ground.")]
    [Range(0f, 89f)] public float maxWalkableSlope = 45f;

    [HideInInspector] public bool isGrounded { get; private set; }
    [HideInInspector] public Vector2 groundNormal { get; private set; }

    [HideInInspector] public Rigidbody2D rb;
    private Collider2D col;

    private float minWalkableNormalY;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        minWalkableNormalY = Mathf.Cos(maxWalkableSlope * Mathf.Deg2Rad);
    }

    void FixedUpdate()
    {
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        Vector2 origin = col.bounds.center;
        float extraHeight = groundCheckDistance;

        RaycastHit2D hit = Physics2D.BoxCast(origin, col.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);

        if (hit.collider != null && hit.normal.y >= minWalkableNormalY)
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

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    private void OnValidate()
    {
        // Update threshold automatically if value is changed in inspector
        minWalkableNormalY = Mathf.Cos(maxWalkableSlope * Mathf.Deg2Rad);
    }

    private void OnDrawGizmosSelected()
    {
        if (col == null) return;
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawWireCube(col.bounds.center + Vector3.down * groundCheckDistance / 2f, col.bounds.size);
    }
}
