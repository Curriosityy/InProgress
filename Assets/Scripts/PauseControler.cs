using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControler : MonoBehaviour
{
    // Use this for initialization
    public GameObject[] menuPanels;

    private bool paused = false;
    private int activatedPanel = 0;
    private PauseControler pc;
    private ScreenChanger sc;

    private void Start()
    {
        sc = GameMaster.gameMaster.GetComponent<ScreenChanger>();
        foreach (GameObject item in menuPanels)
        {
            item.SetActive(false);
        }
    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        if (pc == null)
        {
            pc = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwapPanel(int activate)
    {
        menuPanels[activatedPanel].SetActive(false);
        menuPanels[activate].SetActive(true);
        activatedPanel = activate;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1f;
            foreach (GameObject item in menuPanels)
            {
                item.SetActive(false);
            }
        }
        else
        {
            paused = true;
            Time.timeScale = 0f;
            menuPanels[0].SetActive(true);
            activatedPanel = 0;
        }
    }

    public void BackToMenu()
    {
        sc.FadeToLevel(0);
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}