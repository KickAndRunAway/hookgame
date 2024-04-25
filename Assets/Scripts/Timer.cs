using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = -3;
    public TextMeshProUGUI text;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 0)
        {
            text.text = "-" + (-(int)(timer / 600) % 10).ToString() + (-(int)(timer / 60) % 10).ToString() + ":" + (-(int)((timer % 60) / 10)).ToString() + (-(int)((timer % 60) % 10)).ToString() + ":" + (-(int)(((timer * 100) % 100) / 10)).ToString() + (-(int)((timer * 100) % 100) % 10).ToString();
        }
        else
        {
            text.color = new Color32(255, 255, 255, 255);
            text.text = ((int)(timer / 600) % 10).ToString() + ((int)(timer / 60) % 10).ToString() + ":" + ((int)((timer % 60) / 10)).ToString() + ((int)((timer % 60) % 10)).ToString() + ":" + ((int)(((timer * 100) % 100) / 10)).ToString() + ((int)((timer * 100) % 100) % 10).ToString();
        }
        
    }
    
}