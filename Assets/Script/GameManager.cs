using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject characterPrefab;
    public CameraFollow cameraFollowScript; // Reference to the CameraFollow script

    private GameObject characterInstance;

    void Start()
    {
        SpawnCharacter();
    }

    void SpawnCharacter()
    {
        // Instantiate the character at the spawn point determined by the DetermineSpawnPoint script
        Vector3 spawnPosition = DetermineSpawnPoint.LoadLastSceneSpawnLocation();
        characterInstance = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

        // Assign the character's transform as the target for the camera follow script
        cameraFollowScript.target = characterInstance.transform;
    }
}
