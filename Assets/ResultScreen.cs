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
    public void Setup(float finalTime)
    {
        //Debug.Log("lol");
        Timer.SetActive(false);
        Results.SetActive(true);
        timeText.text = ((int)(finalTime / 600) % 10).ToString() + ((int)(finalTime / 60) % 10).ToString() + ":" + ((int)((finalTime % 60) / 10)).ToString() + ((int)((finalTime % 60) % 10)).ToString() + ":" + ((int)(((finalTime * 100) % 60) / 10)).ToString() + ((int)((finalTime * 100) % 60) % 10).ToString();
    }
}
