using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI split1Text;
    public TextMeshProUGUI split2Text;
    public TextMeshProUGUI split3Text;
    public TextMeshProUGUI top1;
    public TextMeshProUGUI top2;
    public TextMeshProUGUI top3;
    public TextMeshProUGUI top4; 
    public TextMeshProUGUI top5;
    public GameObject Results;
    public GameObject Timer;
    public ScoreManager ScoreManager;

    public void Setup(float finalTime, int finalFuel, float keySplit1, float keySplit2, float keySplit3)
    {
        ScoreManager.Instance.AddScore(finalTime); // neuer score wird dem save file hinzugefügt
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>(); //importiert score liste
        if (scoreManager != null)
        {
            List<float> scores = scoreManager.scores;
            if (scoreManager.scores.Count >= 1) //wenn mindestens 1 vorheriger score, farbe ändern, score float zu string, wenn dieser score der jetzige ist, wird er kursiv
            {
                Color(scoreManager.scores[scoreManager.scores.Count - 1], top1);
                top1.text = TimeToString(scoreManager.scores[scoreManager.scores.Count - 1]);
                if (scoreManager.scores[scoreManager.scores.Count - 1] == finalTime)
                {
                    top1.fontStyle = FontStyles.Italic;
                }          
            }
            else
            {
                top1 = null;
            }
            if (scoreManager.scores.Count >= 2) //wie oben aber für zweitbesten score, geht so weiter für top 5
            {
                Color(scoreManager.scores[scoreManager.scores.Count - 2], top2);
                top2.text = TimeToString(scoreManager.scores[scoreManager.scores.Count - 2]);
                if (scoreManager.scores[scoreManager.scores.Count - 2] == finalTime)
                {
                    top2.fontStyle = FontStyles.Italic;
                }
            }
            else
            {
                top2 = null;
            }
            if (scoreManager.scores.Count >= 3)
            {
                Color(scoreManager.scores[scoreManager.scores.Count - 3], top3);
                top3.text = TimeToString(scoreManager.scores[scoreManager.scores.Count - 3]);
                if (scoreManager.scores[scoreManager.scores.Count - 3] == finalTime)
                {
                    top3.fontStyle = FontStyles.Italic;
                }
            }
            else
            {
                top3 = null;
            }
            if (scoreManager.scores.Count >= 4)
            {
                Color(scoreManager.scores[scoreManager.scores.Count - 4], top4);
                top4.text = TimeToString(scoreManager.scores[scoreManager.scores.Count - 4]);
                if (scoreManager.scores[scoreManager.scores.Count - 4] == finalTime)
                {
                    top4.fontStyle = FontStyles.Italic;
                }
            }
            else
            {
                top4 = null;
            }
            if (scoreManager.scores.Count >= 5)
            {
                Color(scoreManager.scores[scoreManager.scores.Count - 5], top5);
                top5.text = TimeToString(scoreManager.scores[scoreManager.scores.Count - 5]);
                if (scoreManager.scores[scoreManager.scores.Count - 5] == finalTime)
                {
                    top5.fontStyle = FontStyles.Italic;
                }
            }
            else
            {
                top5 = null;
            }
        }
            //Debug.Log(ScoreManager.scores);
            Timer.SetActive(false); //timer auf dem bildschrim weg
        Results.SetActive(true); // resultate bildschrim wird gezeigt
        Color(finalTime, timeText);
        UnityEngine.Debug.Log(finalTime);
        timeText.text = TimeToString(finalTime); //zeit display
        split1Text.text = "1: " + TimeToString(keySplit1);
        split2Text.text = "2: " + TimeToString(keySplit2);
        split3Text.text = "3: " + TimeToString(keySplit3);
        fuelText.text = finalFuel.ToString();
    }

    private string TimeToString(float time) //score float in sekunden zu string der in minuten : sekunden : millisekunden angezeigt wird
    {
        return ((int)(time / 600) % 10).ToString() + ((int)(time / 60) % 10).ToString() + ":" + ((int)((time % 60) / 10)).ToString() + ((int)((time % 60) % 10)).ToString() + ":" + ((int)(((time * 100) % 100) / 10)).ToString() + ((int)((time * 100) % 100) % 10).ToString();
    }
    private void Color(float finalT, TextMeshProUGUI text) //ändert score text farbe je nach dem wie gut die zeit war
    {
        if (finalT > 140f) // färbt die zielzeit je nach speed
        {
            text.color = new Color32(205, 127, 50, 255);
        }
        else if (finalT > 90f)
        {
            text.color = new Color32(192, 192, 192, 255);
        }
        else if (finalT > 60f)
        {
            text.color = new Color32(212, 175, 55, 255);
        }
        else if (finalT > 43.03f)
        {
            text.color = new Color32(184, 216, 231, 255);
        }
        else
        {
            text.color = new Color32(224, 17, 95, 255);
        }
    }
}
