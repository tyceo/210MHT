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


    //toms code
    public float moveSpeed = 2f; // Speed of the platform's movement
    public float moveRange = 3f; // Maximum distance the platform moves from its start point
    public bool startMovingUp = true; // Initial direction of the platform's movement

    private Vector3 startPosition; // The starting position of the platform
    private bool movingUp; // Current direction of the platform's movement


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

        //Apply the mutations!
        gameObject.GetComponent<SpriteRenderer>().sprite = platformSprite;
        gameObject.GetComponent<SpriteRenderer>().color = platformColor;
        transform.localScale = new Vector2(platformXScale, platformYScale);
        moveSpeed = platformMoveSpeed;

        //toms code
        // Record the starting position
        startPosition = transform.position;

        // Set the initial direction
        movingUp = startMovingUp;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }
    private void MovePlatform()
    {
        //Move if the mutation is set to "Moving"
        if(platformBehaviour == "Moving")
        {

            // Determine the direction
            if (movingUp)
            {
                // Move up
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;

                // Check if the platform has reached the top
                if (transform.position.y >= startPosition.y + moveRange)
                {
                    movingUp = false;
                }
            }
            else
            {
                // Move down
                transform.position += Vector3.down * moveSpeed * Time.deltaTime;

                // Check if the platform has reached the bottom
                if (transform.position.y <= startPosition.y - moveRange)
                {
                    movingUp = true;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
            print("touch");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
            print("touch no more");
        }
    }
}
