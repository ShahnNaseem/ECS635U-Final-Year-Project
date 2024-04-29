using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance; // Singleton instance

    public GameObject inventoryPanel;
    public GameObject inventoryItemPrefab;
    public GameObject[] slots;

    private bool isInventoryVisible = false;

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject); // Makes object persistent across scenes
        //
        //    if (slots == null || slots.Length == 0)
        //    {
        //        slots = GameObject.FindGameObjectsWithTag("InventorySlot");
        //    }
        //}

        //else if (instance != this)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
    }

    private void Start()
    {
        inventoryPanel.SetActive(isInventoryVisible);
    }

    public void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        inventoryPanel.SetActive(isInventoryVisible);
    }

    public void AddItemToInventory(Sprite itemSprite)
    {
        foreach(var slot in slots)
        {
            Image slotImage = slot.GetComponent<Image>();
            if (slot.transform.childCount == 0 || slot.GetComponentInChildren<Image>().sprite == null)
            {
                GameObject item = Instantiate(inventoryItemPrefab, slot.transform, false);
                item.GetComponent<Image>().sprite = itemSprite;

                RectTransform itemRect = item.GetComponent<RectTransform>();
                itemRect.anchoredPosition = Vector2.zero;
                itemRect.sizeDelta = Vector2.zero;
                itemRect.anchorMin = Vector2.zero;
                itemRect.anchorMax = Vector2.one;

                break;
            }
        }
    }
}

