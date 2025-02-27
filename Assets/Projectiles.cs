using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.XR;

public class Projectile: MonoBehaviour
{
    //Declare Variables
    public int objectIndex; //The index of mutations it takes. This determines what enemy type it is.

    //Variables to be derived by mutation manager

    private string projectileBehaviour; //Projectile Behaviour
    private Sprite projectileSprite;    //Projectile sprite
    private float projectileDamage;     //Projectile Damage
    private Color projectileColor;      //Enemy Colour
    private float projectileXScale;     //Projectile Width
    private float projectileYScale;     //Projectile Height
    private float projectileMoveSpeed;  //Projectile Move Speed (Modifier)
    private float projectileGravity;    //Projectile Gravity (Modifier)

    // Start is called before the first frame update
    void Start()
    {
        //Find the mutation manager and take relevent variables.
        GameObject mutationManagerObject = GameObject.Find("MutationManager");
        MutationManager mutationManagerScript = mutationManagerObject.GetComponent<MutationManager>();

        objectIndex = Random.Range(0, mutationManagerScript.mutationProjectileCount);

        //Collect relevent variables
        projectileBehaviour = mutationManagerScript.projectileBehaviour[objectIndex];
        projectileSprite = mutationManagerScript.projectileSprite[objectIndex];
        projectileDamage = mutationManagerScript.projectileDamage[objectIndex];
        projectileXScale = mutationManagerScript.projectileXScale[objectIndex];
        projectileYScale = mutationManagerScript.projectileYScale[objectIndex];
        projectileMoveSpeed = mutationManagerScript.projectileMoveSpeed[objectIndex];
        projectileGravity = mutationManagerScript.projectileGravity[objectIndex];

        //Apply mutation to this index so its different the next time it spawns.
        mutationManagerScript.ApplyMutation("Projectile", objectIndex);
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
