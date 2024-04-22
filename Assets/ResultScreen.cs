using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{

    public TextMeshPro timeText;
    public Timer Timer;
    public void Setup(float finalTime)
    {
        gameObject.SetActive(true);
        timeText.text = ((int)(finalTime / 60)).ToString() + ":" + ((int)(finalTime % 60)).ToString();
    }

}
