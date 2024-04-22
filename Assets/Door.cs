using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool triggerActive = false;
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    public Sprite closedSprite;
    public ResultScreen ResultScreen;
    public Timer Timer;
    public Movement Movement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerActive = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        triggerActive = false;
    }

    private void Update()
    {
        if (Movement.keys == 3)
        {
            spriteRenderer.sprite = openSprite;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResultScreen.Setup(Timer.timer);
            }
        }
        else
        {
            spriteRenderer.sprite = closedSprite;
        }

    }
}