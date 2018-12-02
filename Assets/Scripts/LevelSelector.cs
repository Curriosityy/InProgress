using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levels;
    private GameMaster gm;

    // Use this for initialization
    private void Start()
    {
        if (!PlayerPrefs.HasKey("LevelReached"))
        {
            PlayerPrefs.SetInt("LevelReached", 1);
            PlayerPrefs.Save();
        }
        Debug.Log(PlayerPrefs.GetInt("LevelReached"));

        for (int i = PlayerPrefs.GetInt("LevelReached"); i < levels.Length; i++)
        {
            levels[i].interactable = false;
        }
        gm = GameMaster.gameMaster.GetComponent<GameMaster>();
    }

    public void changeScreen(int levelBuildIndex)
    {
        gm.GetComponent<ScreenChanger>().FadeToLevel(levelBuildIndex);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}