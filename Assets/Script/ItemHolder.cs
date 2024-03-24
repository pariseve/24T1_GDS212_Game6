using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    private const string CloverKey = "HasClover";
    private const string DonutKey = "HasDonut";
    private const string CloverDeactivatedKey = "CloverDeactivated";
    private const string NPCSpriteKey = "NPCSprite"; // Define the key for NPC sprite

    public GameObject cloverPrefab; // Reference to the clover prefab
    public GameObject cloverUIPrefab; // Reference to the UI popup prefab
    public GameObject donutUIPrefab;
    public GameObject dogNPC;
    public Sprite newNPCSprite;

    private bool canGiveClover = false;
    private bool canGiveDonut = false;

    // Start is called before the first frame update
    void Start()
    {
        // Load saved values from PlayerPrefs
        canGiveClover = PlayerPrefs.GetInt(CloverKey, 0) == 1;
        canGiveDonut = PlayerPrefs.GetInt(DonutKey, 0) == 1;


        // Check if the clover was deactivated before
        bool cloverDeactivated = PlayerPrefs.GetInt(CloverDeactivatedKey, 0) == 1;
        if (cloverDeactivated)
        {
            // Deactivate the clover GameObject if it was previously deactivated
            if (cloverPrefab != null)
            {
                cloverPrefab.SetActive(false);
            }
        }

        // Load the NPC sprite from PlayerPrefs
        string npcSpriteName = PlayerPrefs.GetString(NPCSpriteKey, "");
        if (!string.IsNullOrEmpty(npcSpriteName))
        {
            // Find the sprite by its name
            Sprite loadedSprite = newNPCSprite; // Directly use the new NPC sprite variable
            if (loadedSprite != null)
            {
                // Assign the loaded sprite to the NPC sprite renderer
                SpriteRenderer npcSpriteRenderer = dogNPC.GetComponentInChildren<SpriteRenderer>();
                if (npcSpriteRenderer != null)
                {
                    npcSpriteRenderer.sprite = loadedSprite;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (cloverUIPrefab != null && cloverUIPrefab.activeSelf)
            {
                cloverUIPrefab.SetActive(false);
            }
            else if (donutUIPrefab != null && donutUIPrefab.activeSelf)
            {
                donutUIPrefab.SetActive(false);
            }
        }
    }

    public void PickUpClover(Collider2D cloverCollider)
    {
        // Check if the cloverCollider GameObject is null
        if (cloverCollider == null)
        {
            Debug.LogWarning("Clover collider is null.");
            return;
        }

        // Destroy the clover GameObject
        Destroy(cloverCollider.gameObject);
        SetCloverDeactivated();

        PlayerPrefs.SetInt("HasClover", 1);

        // Set canGive to true to indicate the player has the clover
        canGiveClover = true;

        // Activate the pickup UI popup if it's assigned
        if (cloverUIPrefab != null)
        {
            cloverUIPrefab.SetActive(true);
        }
    }

    public void RecieveDonut()
    {
        donutUIPrefab.SetActive(true);
        canGiveDonut = true;

        // Save the updated value to PlayerPrefs
        PlayerPrefs.SetInt(DonutKey, canGiveDonut ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void GiveCloverToNPC()
    {
        if (canGiveClover)
        {
            // Access the SpriteRenderer component of the NPC
            SpriteRenderer npcSpriteRenderer = dogNPC.GetComponentInChildren<SpriteRenderer>();

            // Check if the SpriteRenderer is valid and the new sprite is assigned
            if (npcSpriteRenderer != null && newNPCSprite != null)
            {
                // Change the sprite to the new one
                npcSpriteRenderer.sprite = newNPCSprite;

                // Save the sprite name to PlayerPrefs
                PlayerPrefs.SetString(NPCSpriteKey, newNPCSprite.name);
                PlayerPrefs.Save();
            }

            // Set the PlayerPrefs for "hasGivenClover" to indicate that the player has given the clover to the NPC
            PlayerPrefs.SetInt("hasGivenClover", 1);
            PlayerPrefs.Save();

            // Update game state or dialogue as needed

            // Reset clover availability
            canGiveClover = false;

            // Save the updated value to PlayerPrefs
            PlayerPrefs.SetInt(CloverKey, 0);
            PlayerPrefs.Save();
        }
    }




    // Call this method when the clover game object is deactivated
    public void SetCloverDeactivated()
    {
        PlayerPrefs.SetInt(CloverDeactivatedKey, 1);
        PlayerPrefs.Save();
    }
}
