using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelector;
    public GameObject options;
    private bool b_menu;
    private bool b_levelSelector;
    private bool b_options;

    private void Start()
    {
        b_levelSelector = false;
        b_menu = true;
        b_options = false;
    }

    public void GoToLevelSelector()
    {
        b_levelSelector = true;
        b_menu = false;
        b_options = false;
        SetScenes();
    }

    public void GoToOptions()
    {
        b_levelSelector = false;
        b_menu = false;
        b_options = true;
        SetScenes();
    }

    public void GoToMenu()
    {
        b_levelSelector = false;
        b_menu = true;
        b_options = false;
        SetScenes();
    }

    private void SetScenes()
    {
        mainMenu.SetActive(b_menu);
        options.SetActive(b_options);
        levelSelector.SetActive(b_levelSelector);
    }

    public void ExitApplication()
    {
    }
}