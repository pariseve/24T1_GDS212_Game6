using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSpawnManager : MonoBehaviour
{
    public GameObject characterPrefab; // Assign the character prefab in the Inspector

    private void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        // Determine the spawn point based on the last scene
        Vector3 spawnPosition = DetermineSpawnPosition();

        // Instantiate the character prefab at the spawn position
        Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 DetermineSpawnPosition()
    {
        string lastSceneName = PlayerPrefs.GetString("LastScene", "");
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        foreach (GameObject spawnPoint in spawnPoints)
        {
            if (spawnPoint.name == lastSceneName + "SpawnPoint") // Assumes spawn point names are "SceneNameSpawnPoint"
            {
                return spawnPoint.transform.position;
            }
        }

        Debug.LogWarning("No spawn point found for scene: " + lastSceneName);
        return Vector3.zero;
    }
}
