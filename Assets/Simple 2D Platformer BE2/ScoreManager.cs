using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ScoreData : MonoBehaviour
{
    public List<int> scores = new List<int>();

    public void AddScore(int score)
    {
        scores.Add(score);
        scores = scores.OrderByDescending(s => s).ToList(); // Sort scores by descending order
    }
}

public class ScoreManager : MonoBehaviour
{
    private const string saveFileName = "scores.json";

    public ScoreData scoreData;

    private void Start()
    {
        LoadScores();
    }

    public void AddScore(int score)
    {
        scoreData.AddScore(score);
        SaveScores();
    }

    private void SaveScores()
    {
        string json = JsonUtility.ToJson(scoreData);
        File.WriteAllText(Application.persistentDataPath + "/" + saveFileName, json);
    }

    private void LoadScores()
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            scoreData = JsonUtility.FromJson<ScoreData>(json);
        }
        else
        {
            scoreData = new ScoreData();
        }
    }
}
