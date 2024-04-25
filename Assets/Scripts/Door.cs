using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool triggerActive = false;
    private float i = 300f;
    private string[] phrases = { "mfw keyless", "caught you lacking keys", "nuh uh", "you really thought", "tryna break in i see you", "im locked genius", "nothing is this easy in life", "try open sesame", "hell naw", "ask a teacher for the key", "does it look like open house to you", "Baldi heard you" };
    public SpriteRenderer spriteRenderer;
    public ResultScreen ResultScreen;
    public Timer Timer;
    public Movement Movement;
    public GrapplingHook GrapplingHook;
    public Animator animator;
    public death death;
    public GameObject DeathTime;
    public GameObject DeathTimeText;
    public GameObject lacking;
    public float keySplit1 = 0;
    public float keySplit2 = 0;
    public float keySplit3 = 0;
    public TextMeshProUGUI textBox;
    public float timer = 0;
    public Animator Animator;

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
        if (Input.GetKeyDown(KeyCode.Space) && triggerActive)
        {
            timer += Time.deltaTime;

            if (Movement.keys == 3) //das level wird abgeschlossen wenn man die tür betritt und alle drei schlüssel hat
            {
                animator.SetBool("allKeys", true);
                ResultScreen.Setup(Timer.timer, death.fuelTanks, keySplit1, keySplit2, keySplit3);
                Movement.goal = true;
                GrapplingHook.goal = true;
                DeathTime.SetActive(false);
                DeathTimeText.SetActive(false);
                Animator.Play("Base Layer.empty", 0, 0);
            }
            else
            {
                textBox.text = phrases[UnityEngine.Random.Range(0, phrases.Length)]; //der spieler wird informiert, dass schlüssel fehlen
                lacking.transform.position = new Vector3(lacking.transform.position.x, 139f, lacking.transform.position.z);
                textBox.color = new Color(textBox.color.r, textBox.color.g, textBox.color.b, 1f);
                lacking.SetActive(true);
                i = 0f;
            }
            
        }

        if (i < 300f) //animation für info pop-up
        {
            lacking.transform.position = new Vector3(lacking.transform.position.x, 139f + i / 90, lacking.transform.position.z);
            textBox.color = new Color(textBox.color.r, textBox.color.g, textBox.color.b, 1f - i / 300);
            i++;
        }
        else if (i == 300f)
        {
            i++;
            lacking.SetActive(false);
        }
    }
}
