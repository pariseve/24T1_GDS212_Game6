using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        // Load the last scene's spawn location and set the player's position
        transform.position = DetermineSpawnPoint.LoadLastSceneSpawnLocation();
    }

    private void Update()
    {
        FlipSprite();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float moveDirection = horizontalInput * moveSpeed;
        rb.velocity = new Vector2(moveDirection, rb.velocity.y);
    }

    private void FlipSprite()
    {
        if (rb.velocity.x < -0.1f && spriteRenderer.flipX) // Moving right and currently facing left
        {
            spriteRenderer.flipX = false; // Don't flip the sprite
        }
        else if (rb.velocity.x > 0.1f && !spriteRenderer.flipX) // Moving left and currently facing right
        {
            spriteRenderer.flipX = true; // Flip the sprite
        }
    }
}
