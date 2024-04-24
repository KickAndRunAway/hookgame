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
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI split1Text;
    public TextMeshProUGUI split2Text;
    public TextMeshProUGUI split3Text;
    public GameObject Results;
    public GameObject Timer;

    public void Setup(float finalTime, int finalFuel, float keySplit1, float keySplit2, float keySplit3)
    {
        ScoreManager.Instance.AddScore(finalTime); // neuer score wird dem save file hinzugefügt
        ScoreManager.Instance.SaveScores(); //falls save file noch nicht existiert wird es erstellt, sonst score gespeichert
        Timer.SetActive(false); //timer auf dem bildschrim weg
        Results.SetActive(true); // resultate bildschrim wird gezeigt
        if (finalTime > 140f) // färbt die zielzeit je nach speed
        {
            timeText.color = new Color32(205, 127, 50, 255);
        }
        else if (finalTime > 90f)
        {
            timeText.color = new Color32(192, 192, 192, 255);
        }
        else if (finalTime > 60f)
        {
            timeText.color = new Color32(212, 175, 55, 255);
        }
        else if (finalTime > 43.03f)
        {
            timeText.color = new Color32(184, 216, 231, 255);
        }
        else
        {
            timeText.color = new Color32(224, 17, 95, 255);
        }
        timeText.text = ((int)(finalTime / 600) % 10).ToString() + ((int)(finalTime / 60) % 10).ToString() + ":" + ((int)((finalTime % 60) / 10)).ToString() + ((int)((finalTime % 60) % 10)).ToString() + ":" + ((int)(((finalTime * 100) % 60) / 10)).ToString() + ((int)((finalTime * 100) % 60) % 10).ToString(); //zeit display
        split1Text.text = "1: " + ((int)(keySplit1 / 600) % 10).ToString() + ((int)(keySplit1 / 60) % 10).ToString() + ":" + ((int)((keySplit1 % 60) / 10)).ToString() + ((int)((keySplit1 % 60) % 10)).ToString() + ":" + ((int)(((keySplit1 * 100) % 60) / 10)).ToString() + ((int)((keySplit1 * 100) % 60) % 10).ToString();
        split2Text.text = "2: " + ((int)(keySplit2 / 600) % 10).ToString() + ((int)(keySplit2 / 60) % 10).ToString() + ":" + ((int)((keySplit2 % 60) / 10)).ToString() + ((int)((keySplit2 % 60) % 10)).ToString() + ":" + ((int)(((keySplit2 * 100) % 60) / 10)).ToString() + ((int)((keySplit2 * 100) % 60) % 10).ToString();
        split3Text.text = "3: " + ((int)(keySplit3 / 600) % 10).ToString() + ((int)(keySplit3 / 60) % 10).ToString() + ":" + ((int)((keySplit3 % 60) / 10)).ToString() + ((int)((keySplit3 % 60) % 10)).ToString() + ":" + ((int)(((keySplit3 * 100) % 60) / 10)).ToString() + ((int)((keySplit3 * 100) % 60) % 10).ToString();
        fuelText.text = finalFuel.ToString();
    }
}
