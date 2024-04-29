using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentInteraction : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Sprite documentSprite;
    public ItemCollected itemCollected;
    private bool isCollected = false;

    public void OnInteract()
    {
        if (!isCollected)
        {
            Debug.Log("Document has been interacted with.");
            CollectDocuments();
        }
    }

    private void CollectDocuments()
    {
        isCollected = true;
        Debug.Log("Documents have been collected");

        if (inventoryManager != null && documentSprite != null)
        {
            inventoryManager.AddItemToInventory(documentSprite);
        }
        else
        {
            Debug.LogError("InventoryManager or book sprite is missing from DocumentInteraction.");
        }

        if (itemCollected != null)
        {
            itemCollected.ShowMessage("Mission Item Collected");
        }
        else
        {
            Debug.LogWarning("MessageDisplay reference not set in the inspector.");
        }

        gameObject.SetActive(false);
    }
}

