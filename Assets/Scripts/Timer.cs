using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = -3;
    public TextMeshProUGUI text;
    public GameObject GoObject;
    public TextMeshProUGUI Go;
    public GameObject PlayingObject;
    public TextMeshProUGUI Playing;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 0)
        {
            text.text = "-" + (-(int)(timer / 600) % 10).ToString() + (-(int)(timer / 60) % 10).ToString() + ":" + (-(int)((timer % 60) / 10)).ToString() + (-(int)((timer % 60) % 10)).ToString() + ":" + (-(int)(((timer * 100) % 100) / 10)).ToString() + (-(int)((timer * 100) % 100) % 10).ToString();

            PlayingObject.transform.localPosition = new Vector3(PlayingObject.transform.localPosition.x, 410f + (3 + timer) * 16, PlayingObject.transform.localPosition.z);
            Playing.color = new Color(Playing.color.r, Playing.color.g, Playing.color.b, - timer / 2);
        }
        else
        {
            text.color = new Color32(255, 255, 255, 255);
            text.text = ((int)(timer / 600) % 10).ToString() + ((int)(timer / 60) % 10).ToString() + ":" + ((int)((timer % 60) / 10)).ToString() + ((int)((timer % 60) % 10)).ToString() + ":" + ((int)(((timer * 100) % 100) / 10)).ToString() + ((int)((timer * 100) % 100) % 10).ToString();

            PlayingObject.SetActive(false);
            GoObject.SetActive(true);
            GoObject.transform.localPosition = new Vector3(GoObject.transform.localPosition.x, -454f + timer * 16, GoObject.transform.localPosition.z);
            Go.color = new Color(Go.color.r, Go.color.g, Go.color.b, 1f - timer / 2);
        }
        
    }
    
}
