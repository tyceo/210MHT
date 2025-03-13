using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Lose : MonoBehaviour
{
    // The name of the scene to load
    public string sceneName = "SampleScene";

    // The delay in seconds before changing the scene
    public float delay = 5f;

    void Start()
    {
        // Start the coroutine to wait and then change the scene
        StartCoroutine(WaitAndChangeScene());
    }

    IEnumerator WaitAndChangeScene()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Change to the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
