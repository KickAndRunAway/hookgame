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
            if (triggerActive) //wenn player nahe beim item ändert sich das item aussehen um zu zeigen, dass man interagieren kann
            {
                spriteRenderer.sprite = nearSprite;
                if (Input.GetKeyDown(KeyCode.Space)) //interaktion initiiert, item wird benutzt
                {
                    used = true;
                }
            }
            else //item weit weg, geht zum normalen aussehen zurück
            {
                spriteRenderer.sprite = farSprite;
            }
        }
        else //item benutzt, geht zum benutzen aussehen
        {
            spriteRenderer.sprite = usedSprite;
        }

    }
}