using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    private const string saveFileName = "scores.json";

    public static ScoreManager Instance { get; private set; }

    public List<float> scores = new List<float>();
    public List<float> allScores = new List<float>();

    private void Awake()
    {
        if (Instance == null) //wenn noch keine instance besteht, wird sie erstellt
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //wird nach dem erneuten laden nicht zerstört und ersetzt
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadScores();
    }

    public void AddScore(float score) //fügt neuen score hinzu und sortiert zeiten
    {
        scores.Add(score);
        SortScores();
        SaveScores(); 
    }

    public void SaveScores() //erstellt neues save file wenn es noch nicht besteht, sonst speichert es
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(Application.persistentDataPath + "/" + saveFileName, json);
    }

    public void LoadScores() //ladet alle gespeicherten scores von früher in die jetztige scores liste
    {
        string filePath = Application.persistentDataPath + "/" + saveFileName;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            JsonUtility.FromJsonOverwrite(json, this);
            //ScoreManager loadedScoreManager = JsonUtility.FromJson<ScoreManager>(json);

            //allScores.Clear();
            //allScores.AddRange(loadedScoreManager.scores);
            //scores.Clear();
            //scores.AddRange(allScores);
            //scores.AddRange(loadedScoreManager.scores);
        }
    }

    private void SortScores()
    {
        scores = scores.OrderByDescending(s => s).ToList();
    }
}
