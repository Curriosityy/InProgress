using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levels;

    // Use this for initialization
    private void Start()
    {
        if (!PlayerPrefs.HasKey("LevelReached"))
        {
            PlayerPrefs.SetInt("LevelReached", 1);
            PlayerPrefs.Save();
        }
        for (int i = PlayerPrefs.GetInt("LevelReached"); i < levels.Length; i++)
        {
            levels[i].interactable = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}