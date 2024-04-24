using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpriteSelect : MonoBehaviour
{
    public Animator animator;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("alt", true); //animator kann nur noch low poly animationen abspielen
            animator.Play("Base Layer.empty", 0, 0); //animator geht zu 'empty' zurück und geht von dort zur richtigen animation
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetBool("alt", false); //umgekehrte version von oben
            animator.Play("Base Layer.empty", 0, 0);
        }
    }
}
