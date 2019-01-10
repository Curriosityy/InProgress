using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanelControler : MonoBehaviour
{
    private AudioSource playerSource;
    private AudioSource bgSource;
    public Slider bgSlider;
    public Slider fxSlider;

    // Use this for initialization
    private void Start()
    {
        playerSource = GameMaster.gameMaster.GetComponent<GameMaster>().PlayerSource;
        bgSource = GameMaster.gameMaster.GetComponent<GameMaster>().BackgroundSource;
        bgSlider.value = bgSource.volume;
        fxSlider.value = playerSource.volume;
    }

    public void changeVolume(int i)
    {
        switch (i)
        {
            case 1:
                PlayerPrefs.SetFloat("BGValue", bgSlider.value);
                bgSource.volume = bgSlider.value;
                break;

            case 2:
                PlayerPrefs.SetFloat("FXValue", fxSlider.value);
                playerSource.volume = fxSlider.value;
                break;

            default:
                break;
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}