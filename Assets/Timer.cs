using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public TextMeshProUGUI text;
    public GameObject Results;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.text = ((int)(timer/600)%10).ToString() + ((int)(timer/60)%10).ToString() + ":" + ((int)((timer%60)/10)).ToString() + ((int)((timer%60)%10)).ToString() + ":" + ((int)(((timer*100)%60)/10)).ToString() + ((int)((timer*100)%60)%10).ToString();
        if (Results.active)
        {
            gameObject.SetActive(false);
        }
    }
    
}
