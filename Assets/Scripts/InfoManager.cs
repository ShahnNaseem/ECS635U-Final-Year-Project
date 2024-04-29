using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public GameObject infoPanel;
    private bool isInfoVisible = false;

    private void Start()
    {
        infoPanel.SetActive(isInfoVisible);
    }

    public void ToggleInfo()
    {
        isInfoVisible = !isInfoVisible;
        infoPanel.SetActive(isInfoVisible);
    }
}
