using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public void ChangeToLevel(int i)
    {
        ScreenChanger.gameMaster.GetComponent<ScreenChanger>().FadeToLevel(i);
    }
}