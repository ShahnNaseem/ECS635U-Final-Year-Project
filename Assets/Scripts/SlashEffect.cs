using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlashEffect : MonoBehaviour
{
    public Image slashImage;
    public float duration = 0.5f;

    private void Awake()
    {
        if (slashImage == null)
        {
            Debug.LogError("SlashEffect: No slash image assigned!");
            this.enabled = false;
        }
        else
        {
            slashImage.enabled = false;
        }
    }

    public void PlayEffect()
    {
        if (slashImage != null)
        {
            slashImage.enabled = true;
            Invoke("HideEffect", duration);
        }
    }

    private void HideEffect()
    {
        if (slashImage != null)
        {
            slashImage.enabled = false;
        }
    }
}

