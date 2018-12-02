using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public void ChangeToLevel(int i)
    {
        GameMaster.gameMaster.GetComponent<ScreenChanger>().FadeToLevel(i);
    }
}