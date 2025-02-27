using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.XR;

public class Platform : MonoBehaviour
{
    //Declare Variables
    public int objectIndex; //The index of mutations it takes. This determines what platform type it is.

    //Variables to be derived by mutation manager
    private string platformBehaviour;  //Platform behaviour
    private Sprite platformSprite;     //Platform sprite
    private Color platformColor;       //Platform Color
    private float platformXScale;      //Platform Width
    private float platformYScale;      //Platform Height
    private float platformMoveSpeed;   //Platform Move Speed (Modifier)
    private float platformGravity;     //Platform Gravity (Modifier)

    // Start is called before the first frame update
    void Start()
    {
        //Find the mutation manager and take relevent variables.
        GameObject mutationManagerObject = GameObject.Find("MutationManager");
        MutationManager mutationManagerScript = mutationManagerObject.GetComponent<MutationManager>();

        objectIndex = Random.Range(0, mutationManagerScript.mutationPlatformCount);

        //Collect relevent variables
        platformBehaviour = mutationManagerScript.platformBehaviour[objectIndex];
        platformSprite = mutationManagerScript.platformSprite[objectIndex];
        platformColor = mutationManagerScript.platformColor[objectIndex];
        platformXScale = mutationManagerScript.platformXScale[objectIndex];
        platformYScale = mutationManagerScript.platformYScale[objectIndex];
        platformMoveSpeed = mutationManagerScript.platformMoveSpeed[objectIndex];
        platformGravity = mutationManagerScript.platformGravity[objectIndex];

        //Apply mutation to this index so its different the next time it spawns.
        mutationManagerScript.ApplyMutation("Platform", objectIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
