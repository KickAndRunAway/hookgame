using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timeExtend : MonoBehaviour
{
    private bool triggerActive = false;
    private bool used = false;
    public SpriteRenderer spriteRenderer;
    public Sprite farSprite;
    public Sprite nearSprite;
    public Sprite usedSprite;
    public death death;
    public GameObject fuelPopup;
    public TextMeshProUGUI popupText;
    private float i = 300f;

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
                    death.increaseDeathTime();
                    i = 0f;
                    popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, 1f);
                    fuelPopup.transform.localPosition = new Vector3(fuelPopup.transform.localPosition.x, -454f, fuelPopup.transform.localPosition.z);
                    fuelPopup.SetActive(true);

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

        if (i < 300f)
        {
            fuelPopup.transform.localPosition = new Vector3(fuelPopup.transform.localPosition.x, -454f + i / 20, fuelPopup.transform.localPosition.z);
            popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, 1f - i / 300);
            i++;
        }
        else if (i == 300f)
        {
            i++;
            fuelPopup.SetActive(false);
        }
    }
}