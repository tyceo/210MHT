using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.XR;

public class Enemy : MonoBehaviour
{
    //Declare Variables
    public int objectIndex; //The index of mutations it takes. This determines what enemy type it is.

    //Variables to be derived by mutation manager
    public string enemyBehaviour; //Enemy AI.
    public Sprite enemySprite;    //Enemy sprite.
    public float enemyHealth;    //Enemy Maximum Health
    public float enemyDamage;    //Enemy Damage
    public Color enemyColor;     //Enemy Colour
    public float enemyXScale;    //Enemy Width
    public float enemyYScale;    //Enemy Height
    public float enemyMoveSpeed; //Enemy Move/Fly Speed (Modifier)
    public float enemyJumpForce; //Enemy Move Speed (Modifier)
    public float enemyGravity;   //Enemy Gravity (Modifier)
    public bool enemyCanShoot;      //If the enemy can shoot projectiles.
    public int enemyProjectileType; //The index of the projectile the enemy uses when shooting.
    public float enemyShootSpeed;   //Enemy projectile shooting speed.

    // Start is called before the first frame update
    void Start()
    {
        //Find the mutation manager and take relevent variables.
        GameObject mutationManagerObject = GameObject.Find("MutationManager");
        MutationManager mutationManagerScript = mutationManagerObject.GetComponent<MutationManager>();

        //objectIndex = Random.Range(0, mutationManagerScript.mutationEnemyCount);

        //Collect relevent variables
        enemyBehaviour = mutationManagerScript.enemyBehaviour[objectIndex];
        enemySprite = mutationManagerScript.enemySprite[objectIndex];
        enemyHealth = mutationManagerScript.enemyHealth[objectIndex];
        enemyDamage = mutationManagerScript.enemyDamage[objectIndex];
        enemyColor = mutationManagerScript.enemyColor[objectIndex];
        enemyXScale = mutationManagerScript.enemyXScale[objectIndex];
        enemyYScale = mutationManagerScript.enemyYScale[objectIndex];
        enemyMoveSpeed = mutationManagerScript.enemyMoveSpeed[objectIndex];
        enemyJumpForce = mutationManagerScript.enemyJumpForce[objectIndex];
        enemyGravity = mutationManagerScript.enemyGravity[objectIndex];
        enemyCanShoot = mutationManagerScript.enemyCanShoot[objectIndex];
        enemyProjectileType = mutationManagerScript.enemyProjectileType[objectIndex];
        enemyShootSpeed = mutationManagerScript.enemyShootSpeed[objectIndex];

        //Apply mutation to this index so its different the next time it spawns.
        mutationManagerScript.ApplyMutation("Enemy", objectIndex);





        //Apply changes
        gameObject.transform.localScale = new Vector3(enemyXScale, enemyYScale, 0);
        gameObject.GetComponent<Renderer>().material.color = enemyColor;

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
