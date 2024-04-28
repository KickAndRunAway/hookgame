using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool triggerActive = false;
    private bool used = false;
    private int i = 0;
    public SpriteRenderer spriteRenderer;
    public Movement Movement;
    public Timer Timer;
    public Door Door;
    public GameObject splittextbox;
    public TextMeshProUGUI splittext;

    private string TimeToString(float time) //score float in sekunden zu string der in minuten : sekunden : millisekunden angezeigt wird
    {
        return ((int)(time / 600) % 10).ToString() + ((int)(time / 60) % 10).ToString() + ":" + ((int)((time % 60) / 10)).ToString() + ((int)((time % 60) % 10)).ToString() + ":" + ((int)(((time * 100) % 100) / 10)).ToString() + ((int)((time * 100) % 100) % 10).ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) //player in der item hitbox
    {
        triggerActive = true;
    }

    public void OnTriggerExit2D(Collider2D other) //player nicht in der item hitbox
    {
        triggerActive = false;
    }

    private void Update()
    {
        if (!used) //wenn noch nitch benutzt
        {
            if (triggerActive) //wenn player nahe beim item kann man interagieren
            {
                if (Input.GetKeyDown(KeyCode.Space)) //interaktion initiert, item wird benutzt
                {
                    used = true;
                    Movement.keys ++;
                    if (Movement.keys == 1) //zeitpunkt zu dem der schlüssel aufgesammelt wird, wird aufgeschrieben
                    {
                        Door.keySplit1 = Timer.timer;

                    }
                    else if (Movement.keys == 2)
                    {
                        Door.keySplit2 = Timer.timer;
                    }
                    else
                    {
                        Door.keySplit3 = Timer.timer;
                    }
                    splittext.text = TimeToString(Timer.timer);
                    splittextbox.SetActive(true);
                    i = 240;
                }
            }
        }
        else // item benutzt, sprite leer, item verschwindet aus der spieler sicht
        {
            spriteRenderer.sprite = null;
        }
        i--;
        if (i == 0)
        {
            splittextbox.SetActive(false);
        }

    }
}