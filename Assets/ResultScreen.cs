using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public GameObject Results;
    public GameObject Timer;
    public ScoreManager sm;
    public void Setup(float finalTime)
    {
        //Debug.Log("lol");
        Timer.SetActive(false);
        Results.SetActive(true);
        string yourTime = ((int)(finalTime / 600) % 10).ToString() + ((int)(finalTime / 60) % 10).ToString() + ":" + ((int)((finalTime % 60) / 10)).ToString() + ((int)((finalTime % 60) % 10)).ToString() + ":" + ((int)(((finalTime * 100) % 60) / 10)).ToString() + ((int)((finalTime * 100) % 60) % 10).ToString();
        timeText.text = yourTime;
    }
}
