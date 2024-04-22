using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool triggerActive = false;
    private bool used = false;
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    public Sprite closedSprite;
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
            if (Input.GetKeyDown(KeyCode.Space) && triggerActive)
            {

            }
        }
        else
        {
            spriteRenderer.sprite = closedSprite;
        }

    }
}