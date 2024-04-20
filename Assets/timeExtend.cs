using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeExtend : MonoBehaviour
{
    private bool triggerActive = false;
    private bool used = false;
    public SpriteRenderer spriteRenderer;
    public Sprite farSprite;
    public Sprite nearSprite;
    public Sprite usedSprite;

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