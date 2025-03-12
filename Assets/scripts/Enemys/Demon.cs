using UnityEngine;

public class Demon : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePoint; // Point where the bullet is spawned
    public float minShootInterval = 2f; // Minimum time between shots
    public float maxShootInterval = 4f; // Maximum time between shots

    private float shootTimer;

    //Mutation Stuff
    public int objectIndex;

    private Sprite enemySprite;    //Enemy sprite.
    private float enemyDamage;    //Enemy Damage
    private Color enemyColor;     //Enemy Colour
    private float enemyXScale;    //Enemy Width
    private float enemyYScale;    //Enemy Height
    private int enemyProjectileType; //The index of the projectile the enemy uses when shooting.
    private float enemyShootSpeed;   //Enemy projectile shooting speed.

    void Start()
    {
        // Set a random initial shoot timer
        //shootTimer = Random.Range(minShootInterval, maxShootInterval);

        //Find the mutation manager and take relevent variables.
        GameObject mutationManagerObject = GameObject.Find("MutationManager");
        MutationManager mutationManagerScript = mutationManagerObject.GetComponent<MutationManager>();

        //Collect relevent variables
        enemySprite = mutationManagerScript.enemySprite[objectIndex];
        enemyDamage = mutationManagerScript.enemyDamage[objectIndex];
        enemyColor = mutationManagerScript.enemyColor[objectIndex];
        enemyXScale = mutationManagerScript.enemyXScale[objectIndex];
        enemyYScale = mutationManagerScript.enemyYScale[objectIndex];
        enemyProjectileType = mutationManagerScript.enemyProjectileType[objectIndex];
        enemyShootSpeed = mutationManagerScript.enemyShootSpeed[objectIndex];

        //Apply mutations
        gameObject.GetComponent<SpriteRenderer>().sprite = enemySprite;
        gameObject.GetComponent<SpriteRenderer>().color = enemyColor;
        transform.localScale = new Vector2(enemyXScale, enemyYScale);
        minShootInterval = enemyShootSpeed * 0.8f;
        maxShootInterval = enemyShootSpeed * 1.2f;
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
