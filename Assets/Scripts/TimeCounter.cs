using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public float timer = 0;
    public TextMeshProUGUI timerText;

    private void Update()
    {
        timer += Time.deltaTime;
        timerText.text = string.Format("{0:0.00}", timer);
    }
}