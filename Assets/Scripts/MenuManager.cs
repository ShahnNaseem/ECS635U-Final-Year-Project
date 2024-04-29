using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public bool isOptionsVisible = false;

    public GameObject aboutPanel;
    public bool isAboutVisible = false;

    private void Start()
    {
        optionsPanel.SetActive(isOptionsVisible);
        aboutPanel.SetActive(isAboutVisible);
    }

    public void ToggleOptions()
    {
        isOptionsVisible = !isOptionsVisible;
        optionsPanel.SetActive(isOptionsVisible);
    }

    public void ToggleAbout()
    {
        isAboutVisible = !isAboutVisible;
        aboutPanel.SetActive(isAboutVisible);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
