using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathTime : MonoBehaviour
{
    private float timer = -3f;
    public float deathTime = 180f;
    public TextMeshProUGUI CountdownText;
    void Update()
    {
        if (gameObject.activeSelf)
        {
            timer += Time.deltaTime;
            float timeLeft = deathTime - timer;
            CountdownText.text = ((int)(timeLeft / 600) % 10).ToString() + ((int)(timeLeft / 60) % 10).ToString() + ":" + ((int)((timeLeft % 60) / 10)).ToString() + ((int)((timeLeft % 60) % 10)).ToString() + ":" + ((int)(((timeLeft * 100) % 100) / 10)).ToString() + ((int)((timeLeft * 100) % 100) % 10).ToString();

        }
    }
}
