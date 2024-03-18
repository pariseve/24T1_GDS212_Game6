using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust speed as needed
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input

        // Move the player left or right
        Vector2 movement = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);
        rb.velocity = movement;

        // Flip the character sprite
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // Facing left, flip the sprite
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // Facing right, don't flip the sprite
        }
    }
}
