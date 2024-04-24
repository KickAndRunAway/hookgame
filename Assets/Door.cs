using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool triggerActive = false;
    public SpriteRenderer spriteRenderer;
    public ResultScreen ResultScreen;
    public Timer Timer;
    public Movement Movement;
    public Animator animator;
    public death death;
    public float keySplit1 = 0;
    public float keySplit2 = 0;
    public float keySplit3 = 0;

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
            if (Movement.keys == 3)
            {
                animator.SetBool("allKeys", true);
                ResultScreen.Setup(Timer.timer, death.fuelTanks, keySplit1, keySplit2, keySplit3);
            }
            else
            {
                //show text that you are lacking
            }
            
        }
    }
}
