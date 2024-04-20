using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool triggerActive = false;
    private bool used = false;
    public SpriteRenderer spriteRenderer;
    public Sprite farSprite;
    public Sprite nearSprite;
    public Sprite usedSprite;
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
        if (!used)
        {
            if (triggerActive)
            {
                spriteRenderer.sprite = nearSprite;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //function here
                    used = true;
                    Movement.keys ++;
                }
            }
            else
            {
                spriteRenderer.sprite = farSprite;
            }
        }
        else
        {
            spriteRenderer.sprite = usedSprite;
        }

    }
}