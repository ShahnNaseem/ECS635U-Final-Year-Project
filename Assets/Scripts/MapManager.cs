using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public GameObject mapPanel;
    private bool isMapVisible = false;

    private void Start()
    {
        mapPanel.SetActive(isMapVisible);
    }

    public void ToggleMap()
    {
        isMapVisible = !isMapVisible;
        mapPanel.SetActive(isMapVisible);
    }

    public void goLocation0()
    {
        SceneManager.LoadScene(0);
    }
    
    public void goLocation1()
    {
        SceneManager.LoadScene(1);
    }

    public void goLocation2()
    {
        SceneManager.LoadScene(2);
    }
    public void goLocation3()
    {
        SceneManager.LoadScene(3);
    }

    public void goLocation4()
    {
        SceneManager.LoadScene(4);
    }

    public void goLocation5()
    {
        SceneManager.LoadScene(5);
    }

}
