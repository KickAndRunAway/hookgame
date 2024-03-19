using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeExtend : MonoBehaviour
{
    private bool triggerActive = false;
    private bool lmao = false;
    public SpriteRenderer spriteRenderer;
    public Sprite oldSprite;
    public Sprite newSprite;
    public Sprite lol;

    private void OnTriggerEnter2D(Collider2D other)
    {
        triggerActive = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        triggerActive = false;
    }

    public void ChangeSprite1()
    {
        spriteRenderer.sprite = newSprite;
    }
    public void ChangeSprite2()
    {
        spriteRenderer.sprite = oldSprite;
    }
    private void Update()
    {
        if (!lmao)
        {
            if (triggerActive)
            {
                spriteRenderer.sprite = newSprite;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    lmao = true;
                }
            }
            else
            {
                spriteRenderer.sprite = oldSprite;
            }
        }
        else
        {
            spriteRenderer.sprite = lol;
        }

    }
}