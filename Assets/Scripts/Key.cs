using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool triggerActive = false;
    private bool used = false;
    public SpriteRenderer spriteRenderer;
    public Movement Movement;
    public Timer Timer;
    public Door Door;

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
                    if (Movement.keys == 1)
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
                }
            }
        }
        else // item benutzt, sprite leer, item verschwindet aus der spieler sicht
        {
            spriteRenderer.sprite = null;
        }

    }
}