using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationManager : MonoBehaviour
{
    //Declare variables

    //Runtime Mutation Data =======================================================================================
    public int mutationEnemyCount = 0; //How many enemy entries are saved.
    public int mutationPlatformCount = 0; //How many platform entries are saved.
    public int mutationProjectileCount = 0; //How many projectile entries are saved.

    //each list entry is a enemy. For enemy 1 for example, you use index 0 of each list to create the enemy, enemy 2 uses all 2nd indexes.
    public List<int> enemyTimesMutated; //How many times this enemy has been mutated.
    public List<string> enemyBehaviour; //Enemy AI.
    public List<Sprite> enemySprite;    //Enemy sprite.
    public List<float> enemyHealth;    //Enemy Maximum Health
    public List<float> enemyDamage;    //Enemy Damage
    public List<Color> enemyColor;     //Enemy Colour
    public List<float> enemyXScale;    //Enemy Width
    public List<float> enemyYScale;    //Enemy Height
    public List<float> enemyMoveSpeed; //Enemy Move/Fly Speed (Modifier)
    public List<float> enemyJumpForce; //Enemy Move Speed (Modifier)
    public List<float> enemyGravity;   //Enemy Gravity (Modifier)
    public List<bool> enemyCanShoot;      //If the enemy can shoot projectiles.
    public List<int> enemyProjectileType; //The index of the projectile the enemy uses when shooting.
    public List<float> enemyShootSpeed;   //Enemy projectile shooting speed.

    public List<int> platformTimesMutated; //How many times this platform has been mutated.
    public List<string> platformBehaviour;  //Platform behaviour
    public List<Sprite> platformSprite;     //Platform sprite
    public List<Color> platformColor;       //Platform Color
    public List<float> platformXScale;      //Platform Width
    public List<float> platformYScale;      //Platform Height
    public List<float> platformMoveSpeed;   //Platform Move Speed (Modifier)
    public List<float> platformGravity;     //Platform Gravity (Modifier)

    public List<int> projectileTimesMutated; //How many times this projectile has been mutated.
    public List<string> projectileBehaviour; //Projectile Behaviour
    public List<Sprite> projectileSprite;    //Projectile sprite
    public List<float> projectileDamage;     //Projectile Damage
    public List<Color> projectileColor;      //Enemy Colour
    public List<float> projectileXScale;     //Projectile Width
    public List<float> projectileYScale;     //Projectile Height
    public List<float> projectileMoveSpeed;  //Projectile Move Speed (Modifier)
    public List<float> projectileGravity;    //Projectile Gravity (Modifier)

    //Mutation Limits, defined manually in inspector. =============================================
    public List<string> enemyBehaviourTypes;
    public List<Sprite> enemySprites;

    public List<string> platformBehaviourTypes;
    public List<Sprite> platformSprites;

    public List<string> projectileBehaviourTypes;
    public List<Sprite> projectileSprites;

    // Start is called before the first frame update
    void Start()
    {
        CreateFirstSet(5, 3, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }


    //Creates/Overites the current list of platforms and enemies. 
    void CreateFirstSet(int uniqueEnemies, int uniquePlatforms, int uniqueProjectiles)
    {
        //Clear current lists
        mutationEnemyCount = 0;
        enemyTimesMutated = new List<int>();
        enemyBehaviour = new List<string>();
        enemySprite = new List<Sprite>();
        enemyHealth = new List<float>();
        enemyDamage = new List<float>();
        enemyColor = new List<Color>();
        enemyXScale = new List<float>();
        enemyYScale = new List<float>();
        enemyMoveSpeed = new List<float>();
        enemyJumpForce = new List<float>();
        enemyGravity = new List<float>();
        enemyCanShoot = new List<bool>();
        enemyShootSpeed = new List<float>();

        mutationPlatformCount = 0;
        platformTimesMutated = new List<int>();
        platformBehaviour = new List<string>();
        platformSprite = new List<Sprite>();
        platformColor = new List<Color>();
        platformXScale = new List<float>();
        platformYScale = new List<float>();
        platformMoveSpeed = new List<float>();
        platformGravity = new List<float>();

        mutationProjectileCount = 0;
        projectileTimesMutated = new List<int>();
        projectileBehaviour = new List<string>();
        projectileSprite = new List<Sprite>();
        projectileDamage = new List<float>();
        projectileColor = new List<Color>();
        projectileXScale = new List<float>();
        projectileYScale = new List<float>();
        projectileMoveSpeed = new List<float>();
        projectileGravity = new List<float>();

        //Create set of enemies
        for(int i = 0; i < uniqueEnemies; i++)
        {
            mutationEnemyCount += 1;
            enemyTimesMutated.Add(0);
            enemyBehaviour.Add(enemyBehaviourTypes[Random.Range(0, enemyBehaviourTypes.Count)]);
            enemySprite.Add(enemySprites[Random.Range(0, enemySprites.Count)]);
            enemyHealth.Add(Random.Range(2, 5));
            enemyDamage.Add(Random.Range(1, 3));
            enemyColor.Add(new Color(Random.Range(0F, 1f), Random.Range(0, 1f), Random.Range(0, 1f)));
            enemyXScale.Add(Random.Range(0.8f, 1.2f));
            enemyYScale.Add(Random.Range(0.8f, 1.2f));
            enemyMoveSpeed.Add(Random.Range(0.8f, 1.2f));
            enemyJumpForce.Add(Random.Range(0.8f, 1.2f));
            enemyGravity.Add(Random.Range(0.5f, 1.5f));
            enemyProjectileType.Add(Random.Range(0, uniqueProjectiles));
            enemyCanShoot.Add(Random.value < 0.5f);
            enemyShootSpeed.Add(Random.Range(2, 4));
        }

        //Create set of platforms
        for(int i = 0; i < uniquePlatforms; i++)
        {
            mutationPlatformCount += 1;
            platformTimesMutated.Add(0);
            platformBehaviour.Add(platformBehaviourTypes[Random.Range(0, platformBehaviourTypes.Count)]);
            platformSprite.Add(platformSprites[Random.Range(0, platformSprites.Count)]);
            platformColor.Add(new Color(Random.Range(0F, 1f), Random.Range(0, 1f), Random.Range(0, 1f)));
            platformXScale.Add(Random.Range(2f, 5f));
            platformYScale.Add(Random.Range(0.2f, 1f));
            platformMoveSpeed.Add(Random.Range(0.8f, 1.2f));
            platformGravity.Add(Random.Range(0.5f, 1.5f));
        }

        //Create set of projectiles
        for(int i = 0; i < uniqueProjectiles; i++)
        {
            mutationProjectileCount += 1;
            projectileTimesMutated.Add(0);
            projectileBehaviour.Add(projectileBehaviourTypes[Random.Range(0, projectileBehaviourTypes.Count)]);
            projectileSprite.Add(projectileSprites[Random.Range(0, projectileSprites.Count)]);
            projectileDamage.Add(Random.Range(1, 3));
            projectileColor.Add(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0, 1f)));
            projectileXScale.Add(Random.Range(0.8f, 1.2f));
            projectileYScale.Add(Random.Range(0.8f, 1.2f));
            projectileMoveSpeed.Add(Random.Range(0.5f, 1.5f));
            projectileGravity.Add(Random.Range(-0.5f, 0.5f));
        }

    }

    //Applys changes to values to tweak them next time they spawn. typeToChange can be "Enemy", "Platform" or "Projectile"
    public void ApplyMutation(string typeToChange, int indexToChange)
    {
        Debug.Log("applying changes");
        //Change enemy stats
        if (typeToChange == "Enemy")
        {
            int i = indexToChange;
            enemyTimesMutated[i] += 1;

            //Enemy behaviour changes very rare, and sprite should never change.
            int randomChance = Random.Range(0, 99);
            if (randomChance >= 95)
            {
                enemyBehaviour[i] = enemyBehaviourTypes[Random.Range(0, enemyBehaviourTypes.Count)];
            }

            //Change enemy colour slightly
            float r = enemyColor[i].r;
            float g = enemyColor[i].g;
            float b = enemyColor[i].b;
            r += Random.Range(-0.1f,0.1f);
            g += Random.Range(-0.1f, 0.1f);
            b += Random.Range(-0.1f, 0.1f);
            enemyColor[i] = new Color(r, g, b);

            enemyHealth[i] += Random.Range(-0.5f, 0.5f);
            if(enemyHealth[i] < 0.1f)
            {
                enemyHealth[i] = 0.1f;
            }

            enemyDamage[i] += Random.Range(-0.5f, 0.5f);

            //Scales have lower limits to prevent issues
            enemyXScale[i] += Random.Range(-0.2f, 0.2f);
            enemyYScale[i] += Random.Range(-0.2f, 0.2f);
            if (enemyXScale[i] < 0.1f)
            {
                enemyXScale[i] = 0.1f;
            }
            if (enemyYScale[i] < 0.1f)
            {
                enemyYScale[i] = 0.1f;
            }

            enemyMoveSpeed[i] += Random.Range(-0.5f, 0.5f);
            enemyJumpForce[i] += Random.Range(-0.5f, 0.5f);
            enemyGravity[i] += Random.Range(-0.5f, 0.5f);

            //Enemy CanShoot changing should be rare.
            randomChance = Random.Range(0, 99);
            if (randomChance >= 90)
            {
                enemyCanShoot[i] = !enemyCanShoot[i];
            }

            enemyShootSpeed[i] += Random.Range(-0.5f, 0.5f);
        }

        //Change platform stats
        if (typeToChange == "Platform")
        {
            int i = indexToChange;
            platformTimesMutated[i] += 1;

            //Platform behaviour changes rarely, and sprite should never change.
            int randomChance = Random.Range(0, 99);
            if (randomChance >= 80)
            {
                platformBehaviour[i] = platformBehaviourTypes[Random.Range(0, platformBehaviourTypes.Count)];
            }

            //Change platform colour slightly
            float r = platformColor[i].r;
            float g = platformColor[i].g;
            float b = platformColor[i].b;
            r += Random.Range(-0.1f, 0.1f);
            g += Random.Range(-0.1f, 0.1f);
            b += Random.Range(-0.1f, 0.1f);
            platformColor[i] = new Color(r, g, b);

            //Scales have lower limits to prevent issues
            platformXScale[i] += Random.Range(-0.2f, 0.2f);
            platformYScale[i] += Random.Range(-0.2f, 0.2f);
            if (platformXScale[i] < 0.1f)
            {
                platformXScale[i] = 0.1f;
            }
            if (platformYScale[i] < 0.1f)
            {
                platformYScale[i] = 0.1f;
            }

            platformMoveSpeed[i] += Random.Range(-0.5f, 0.5f);
            platformGravity[i] += Random.Range(-0.5f, 0.5f);
        }

        //Change projectile stats
        if (typeToChange == "Projectile")
        {
            int i = indexToChange;
            projectileTimesMutated[i] += 1;

            //Change projectile colour slightly
            float r = projectileColor[i].r;
            float g = projectileColor[i].g;
            float b = projectileColor[i].b;
            r += Random.Range(-0.1f, 0.1f);
            g += Random.Range(-0.1f, 0.1f);
            b += Random.Range(-0.1f, 0.1f);
            projectileColor[i] = new Color(r, g, b);

            //Projectile behaviour changes rarely, and sprite should never change.
            int randomChance = Random.Range(0, 99);
            if (randomChance >= 95)
            {
                projectileBehaviour[i] = projectileBehaviourTypes[Random.Range(0, projectileBehaviourTypes.Count)];
            }

            projectileDamage[i] += Random.Range(-0.5f, 0.5f);

            //Scales have lower limits to prevent issues
            projectileXScale[i] += Random.Range(-0.2f, 0.2f);
            projectileYScale[i] += Random.Range(-0.2f, 0.2f);
            if (projectileXScale[i] < 0.1f)
            {
                projectileXScale[i] = 0.1f;
            }
            if (projectileYScale[i] < 0.1f)
            {
                projectileYScale[i] = 0.1f;
            }

            projectileMoveSpeed[i] += Random.Range(-0.5f, 0.5f);
            projectileGravity[i] += Random.Range(-0.5f, 0.5f);

        }
    }

}
