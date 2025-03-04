using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    public GameObject[] stagePieces; // Array of stage piece prefabs
    public int numberOfPieces = 10; // Number of pieces to generate per batch
    public float spacing = 20f; // Distance between each piece on the X-axis
    public float spawnInterval = 40f; 

    private int batchNumber = 0; // Tracks the current batch number

    void Start()
    {
        
        StartCoroutine(SpawnBatches());
    }

    IEnumerator SpawnBatches()
    {
        while (true) // Infinite loop to keep spawning batches
        {
            // Spawn a new batch of stage pieces
            GenerateStage(batchNumber);

            // Increment the batch number for the next batch
            batchNumber++;

            // Wait for 40 seconds before spawning the next batch
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void GenerateStage(int batchNumber)
    {
        for (int i = 0; i < numberOfPieces; i++)
        {
            // Randomly select a stage piece from the array
            GameObject randomPiece = stagePieces[Random.Range(0, stagePieces.Length)];

            
            Vector3 originalPosition = randomPiece.transform.position;

            
            Vector3 spawnPosition = new Vector3(
                originalPosition.x + (i * spacing) + (batchNumber * numberOfPieces * spacing),
                originalPosition.y,
                originalPosition.z
            );

            // Instantiate the piece at the calculated position
            GameObject spawnedPiece = Instantiate(randomPiece, spawnPosition, Quaternion.identity);
        }
    }
}
