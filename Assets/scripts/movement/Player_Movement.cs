using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask Ground; 

    private Rigidbody2D rb;
    private bool isGrounded = false;
    public int goingleft;
    public Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector3(0f, -10f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // Check if the player is grounded using raycasting
        isGrounded = IsGrounded();

        // Jumping (using "W" key)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && rb.linearVelocity.y > -0.1 && rb.linearVelocity.y < 0.1)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

        //animation
        if (rb.linearVelocity.x < 0)
        {

            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {

            GetComponent<SpriteRenderer>().flipX = false;
        }


        if (rb.linearVelocity.y < 0 || rb.linearVelocity.y > 0)
        {

            animator.SetBool("Jump", true);
        }
        else
        {

            animator.SetBool("Jump", false);
        }

        if (rb.linearVelocity.x < 0 || rb.linearVelocity.x > 0)
        {

            animator.SetBool("moving", false);
        }
        else
        {

            animator.SetBool("moving", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Spike"))
        {
            SceneManager.LoadScene("Lose");
        }
    }





    private bool IsGrounded()
    {
        Vector2 rayOrigin = transform.position - new Vector3(0f, 1f, 0f); // Slightly below the player's feet


        Vector2 rightOffset = new Vector2(0.39f, 0);
        Vector2 leftOffset = new Vector2(-0.39f, 0);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin + leftOffset, Vector2.down, 0.1f, Ground);
        Debug.DrawRay(rayOrigin + leftOffset, Vector2.down, Color.red);

        RaycastHit2D hitRight = Physics2D.Raycast(rayOrigin + rightOffset, Vector2.down + Vector2.right, 0.1f, Ground);
        Debug.DrawRay(rayOrigin + rightOffset, Vector2.down, Color.red);


        return hit.collider != null || hitRight.collider != null;


    }



}
