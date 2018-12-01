using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    private Camera mainCamera;
    private int activePanel = 0;
    public GameObject[] menuPanels;

    private void Start()
    {
        for (int i = 0; menuPanels.Length > i; i++)
        {
            menuPanels[i].SetActive(false);
        }
        menuPanels[0].SetActive(true);
        activePanel = 0;
    }

    public void GoToIMenu(int activate)
    {
        menuPanels[activePanel].SetActive(false);
        menuPanels[activate].SetActive(true);
        activePanel = activate;
    }

    public void GoToIMenu(Vector2Int vector2)
    {
        menuPanels[vector2.x].SetActive(false);
        menuPanels[vector2.y].SetActive(true);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}