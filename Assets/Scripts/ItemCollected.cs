using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollected : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float displayTime = 2f;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        gameObject.SetActive(true);
        Invoke("HideMessage", displayTime);
    }

    private void HideMessage()
    {
        gameObject.SetActive(false);
    }
}
