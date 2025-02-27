using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawner : MonoBehaviour
{
    //
    GameObject enemyObject;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TestSpawn(int index)
    {
        GameObject newObject = Instantiate(enemyObject, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10),Random.Range(-10, 10)), new Quaternion());
    }
}
