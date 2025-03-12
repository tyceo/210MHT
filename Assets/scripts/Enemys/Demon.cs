using UnityEngine;

public class Demon : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePoint; // Point where the bullet is spawned
    public float minShootInterval = 2f; // Minimum time between shots
    public float maxShootInterval = 4f; // Maximum time between shots

    private float shootTimer;

    void Start()
    {
        // Set a random initial shoot timer
        shootTimer = Random.Range(minShootInterval, maxShootInterval);
    }

    void Update()
    {
        // Count down the shoot timer
        shootTimer -= Time.deltaTime;

        // When the timer reaches 0, shoot and reset the timer
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = Random.Range(minShootInterval, maxShootInterval);
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        else
        {
            Debug.LogWarning("Bullet prefab or fire point is not assigned.");
        }
    }
}
