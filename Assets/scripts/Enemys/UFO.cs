using UnityEngine;

public class UFO : MonoBehaviour
{
    //god please don't look at this mess 
    public float moveSpeed = 3f; //speedmoving left
    public float diveSpeed = 5f; 
    public float returnSpeed = 4f; 
    public float detectionRange = 10f; 

    
    public float diveDuration = 2f; 
    public float stayDuration = 1f; 

    private Transform player; 
    private Vector3 originalPosition; 
    private bool isDiving = false; 
    private bool isStaying = false; 
    private bool isReturning = false; 
    private Vector3 diveTargetPosition; 
    private float diveTimer; 
    private float stayTimer; 

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
        originalPosition = transform.position;
    }

    void Update()
    {
        if (!isDiving && !isStaying && !isReturning)
        {
            
            MoveLeft();

            
            if (IsPlayerInRange())
            {
                StartDive();
            }
        }
        else if (isDiving)
        {
            Dive();
        }
        else if (isStaying)
        {
            Stay();
        }
        else if (isReturning)
        {
            ReturnToHeight();
        }
    }

    void MoveLeft()
    {
        
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    bool IsPlayerInRange()
    {
        
        return Vector3.Distance(transform.position, player.position) <= detectionRange;
    }

    void StartDive()
    {
        
        diveTargetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);

        
        isDiving = true;
        diveTimer = 0f;
    }

    void Dive()
    {
        
        diveTimer += Time.deltaTime;

        
        transform.position = Vector3.MoveTowards(transform.position, diveTargetPosition, diveSpeed * Time.deltaTime);

        
        if (diveTimer >= diveDuration)
        {
            isDiving = false;
            isStaying = true;
            stayTimer = 0f;
        }
    }

    void Stay()
    {
        
        stayTimer += Time.deltaTime;

        
        if (stayTimer >= stayDuration)
        {
            isStaying = false;
            isReturning = true;
        }
    }

    void ReturnToHeight()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, originalPosition, returnSpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, originalPosition) < 0.1f)
        {
            isReturning = false;
        }
    }

    
}
