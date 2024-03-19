using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public bool canGive = false;
    public GameObject pickupUIPrefab; // Reference to the UI popup prefab

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && pickupUIPrefab != null)
        {
            pickupUIPrefab.SetActive(false);
        }
    }

    public bool HasClover()
    {
        return canGive;
    }

    public void PickUpClover(Collider2D cloverCollider)
    {
        // Destroy the clover GameObject
        Destroy(cloverCollider.gameObject);

        // Activate the pickup UI popup
        pickupUIPrefab.SetActive(true);

        // Set canGive to true to indicate the player has the clover
        canGive = true;
    }

    public void GiveCloverToNPC(GameObject npc)
    {
        if (canGive)
        {
            // Transfer the clover to the NPC
            //npc.GetComponent<NPC>().ReceiveClover();

            // Update game state or dialogue as needed

            // Reset clover availability
            canGive = false;
        }
    }
}
