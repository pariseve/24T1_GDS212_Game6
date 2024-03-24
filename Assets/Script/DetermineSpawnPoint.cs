using UnityEngine;
using UnityEngine.SceneManagement;

public class DetermineSpawnPoint : MonoBehaviour
{
    private const string LastSceneKey = "LastScene";

    //private void Start()
    //{
    //    DontDestroyOnLoad(this);
    //}

    // Call this method when the player character leaves a scene
    public static void SaveLastScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString(LastSceneKey, currentSceneName);
        PlayerPrefs.Save(); // Ensure PlayerPrefs changes are saved immediately
    }

    // Call this method when the player character enters a new scene
    public static Vector3 LoadLastSceneSpawnLocation()
    {
        string lastSceneName = LoadLastSceneName();
        if (!string.IsNullOrEmpty(lastSceneName))
        {
            // Determine spawn location based on the last scene
            return DetermineSpawnPosition(lastSceneName);
        }

        Debug.LogWarning("Last scene name is empty or null.");
        return Vector3.zero;
    }

    // Method to load the last scene name from PlayerPrefs
    private static string LoadLastSceneName()
    {
        return PlayerPrefs.GetString(LastSceneKey, "");
    }

    // Method to determine spawn position based on the last scene
    private static Vector3 DetermineSpawnPosition(string lastSceneName)
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        foreach (GameObject spawnPoint in spawnPoints)
        {
            Debug.Log("Checking spawn point: " + spawnPoint.name);
            if (spawnPoint.name == lastSceneName + "SpawnPoint") // Assumes spawn point names are "SceneNameSpawnPoint"
            {
                Debug.Log("Found spawn point for scene: " + lastSceneName);
                return spawnPoint.transform.position;
            }
        }

        // If no spawn point is found, return default position
        Debug.LogWarning("No spawn point found for scene: " + lastSceneName);
        return Vector3.zero;
    }
}
