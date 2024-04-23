using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public GameObject Results;
    public GameObject Timer;
    public void Setup(float finalTime)
    {
        ScoreManager.Instance.AddScore(finalTime); // neuer score wird dem save file hinzugefügt
        ScoreManager.Instance.SaveScores(); //falls save file noch nicht existiert wird es erstellt, sonst score gespeichert
        Timer.SetActive(false); //timer auf dem bildschrim weg
        Results.SetActive(true); // resultate bildschrim wird gezeigt
        timeText.text = ((int)(finalTime / 600) % 10).ToString() + ((int)(finalTime / 60) % 10).ToString() + ":" + ((int)((finalTime % 60) / 10)).ToString() + ((int)((finalTime % 60) % 10)).ToString() + ":" + ((int)(((finalTime * 100) % 60) / 10)).ToString() + ((int)((finalTime * 100) % 60) % 10).ToString(); //zeit display
    }
}
