using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.Search;
using UnityEngine;
using UnityEngine.XR;

public class Enemy : MonoBehaviour
{
    //Declare Variables
    public int objectIndex; //The index of mutations it takes. This determines what enemy type it is.

    //Variables to be derived by mutation manager
    private string enemyBehaviour; //Enemy AI.

    public GameObject spawnDemon;
    public GameObject spawnFlower;
    public GameObject spawnSpikeDude;
    public GameObject spawnUFO;

    // Start is called before the first frame update
    void Start()
    {
        //Find the mutation manager and take relevent variables.
        GameObject mutationManagerObject = GameObject.Find("MutationManager");
        MutationManager mutationManagerScript = mutationManagerObject.GetComponent<MutationManager>();

        objectIndex = Random.Range(0, mutationManagerScript.mutationEnemyCount);

        //Collect relevent variables
        enemyBehaviour = mutationManagerScript.enemyBehaviour[objectIndex];


        //Depending on the enemy type, instantiate the enemy here.
        if (enemyBehaviour == "Demon")
        {
            // Instantiate the demon
            var spawnEnemy = Instantiate(spawnDemon, this.transform);

            // Set the y position to 0
            Vector3 newPosition = spawnEnemy.transform.position;
            newPosition.y = 3f; // Set y to 0
            spawnEnemy.transform.position = newPosition;

            // Set the objectIndex for the demon
            spawnEnemy.GetComponent<Demon>().objectIndex = objectIndex;
        }

        if (enemyBehaviour == "Flower")
        {
            // Instantiate the flower
            var spawnEnemy = Instantiate(spawnFlower, this.transform);

            // Set the y position to 0
            Vector3 newPosition = spawnEnemy.transform.position;
            newPosition.y = 3f; // Set y to 0
            spawnEnemy.transform.position = newPosition;

            // Set the objectIndex for the flower
            spawnEnemy.GetComponent<enemy2Movement>().objectIndex = objectIndex;
        }
        if (enemyBehaviour == "SpikeDude")
        {
            // Instantiate the SpikeDude
            var spawnEnemy = Instantiate(spawnSpikeDude, this.transform);

            // Set the y position to 0
            Vector3 newPosition = spawnEnemy.transform.position;
            newPosition.y = 3f; // Set y to 0
            spawnEnemy.transform.position = newPosition;

            // Uncomment and set the objectIndex for SpikeDude if needed
            // spawnEnemy.GetComponent<Enemy1Movement>().objectIndex = objectIndex;
        }
        if (enemyBehaviour == "UFO")
        {
            var spawnEnemy = Instantiate(spawnUFO, this.transform);
            //spawnEnemy.GetComponent<UFO>().objectIndex = objectIndex;
        }

        //Apply mutation to this index so its different the next time it spawns.
        mutationManagerScript.ApplyMutation("Enemy", objectIndex);

        //Destory this spawner
        Destroy(this);

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
