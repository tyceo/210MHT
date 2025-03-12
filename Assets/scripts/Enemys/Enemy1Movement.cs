using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    //                  THIS ONE GOES BACK AND FORTH LIKE GREEN SHELL MARIO ENEMY


    public float moveSpeed = 2f;
    public LayerMask Ground; // Layer for walls/obstacles
    public Transform groundCheck;

    private bool movingRight = false; // Direction of movement
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckForWall();
    }
    void Move()
    {
        // Move the enemy left or right
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
    }

    void CheckForWall()
    {
        // Cast a ray to detect walls
        float rayLength = 0.1f; // Adjust based on enemy size
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, movingRight ? Vector2.right : Vector2.left, rayLength, Ground);

        // If a wall is detected, flip direction
        if (hit.collider != null)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Reverse direction
        movingRight = !movingRight;

        // Flip the sprite (optional)
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
