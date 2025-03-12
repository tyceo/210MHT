using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    public float speed = 3f; // Speed of the bullet
    public float lifetime = 5f; // Time before the bullet is destroyed if it doesn't hit anything

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = -transform.right * speed; // Move the bullet forward

        // Destroy the bullet after a set lifetime
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet hits an object with the tag "Ground"
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
