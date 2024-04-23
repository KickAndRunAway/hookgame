using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Movement : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float jumpAmount = 10;
    public float MovementSpeed = 10;
    public Vector2 boxSizeV;
    public Vector2 boxSizeH;
    public float castDistanceV;
    public float castDistanceH;
    public LayerMask groundLayer;
    public Vector2 ropeHook;
    public GrapplingHook GrapplingHook;
    public float maxSpeed;
    public int keys = 0;
    public Animator animator;
    public float timer = 0;
    private bool m_FacingRight = true;

// if(GrapplingHook.ropeAttached()) should check if the player is hanging

void Update()
    {
        timer += Time.deltaTime;

        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x)); //wenn geschwindigkeit nicht 0 spielt die walk animation

        if (!isGrounded() && !GrapplingHook.ropeAttached) //nicht auf dem boden oder an der hook
        {
            if (rb.velocity.y > 0) //sprung
            {
                animator.SetBool("hooked", false);
                animator.SetBool("fall", false);
                animator.SetBool("jump", true);
            }
            else if (rb.velocity.y < 0) //fall
            {
                animator.SetBool("hooked", false);
                animator.SetBool("jump", false);
                animator.SetBool("fall", true);
            }
        }
        else if (isGrounded() && !GrapplingHook.ropeAttached) //auf dem boden und nicht an der hook, also idle oder laufen
        {
            animator.SetBool("jump", false);
            animator.SetBool("hooked", false);
            animator.SetBool("fall", false);
        }
        else if (!isGrounded() && GrapplingHook.ropeAttached) //nicht auf dem boden aber an der hook
        {
            animator.SetBool("jump", false);
            animator.SetBool("fall", false);
            animator.SetBool("hooked", true);
        }

        if (rb.velocity.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && m_FacingRight)
        {
            Flip();
        }

        void Flip() //spiegelt den player sprite wenn er sich umdreht
        {
            m_FacingRight = !m_FacingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        if (isGrounded() && Input.GetKeyDown(KeyCode.W)) //jump
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        else

        if (Input.GetKey(KeyCode.A) && isWallLeft() && rb.velocity.x > -maxSpeed) //linke wand kollision
        {
            if (rb.velocity.x > -2)
            {
                rb.AddForce(Vector2.right * -MovementSpeed / 20, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.right * -MovementSpeed / 100, ForceMode2D.Impulse);
            }
        }

        else if (Input.GetKey(KeyCode.D) && isWallRight() && rb.velocity.x < maxSpeed) //rechte wand kollision
        {
            if (rb.velocity.x < 2)
            {
                rb.AddForce(Vector2.right * MovementSpeed / 20, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.right * MovementSpeed / 100, ForceMode2D.Impulse);
            }
        }

        if (GrapplingHook.ropeAttached) //schwung während an der hook
        {
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(Vector2.up * Mathf.Cos(GrapplingHook.aimAngle) / 50, ForceMode2D.Impulse);
                rb.AddForce(Vector2.right * -Mathf.Sin(GrapplingHook.aimAngle) / 50, ForceMode2D.Impulse);
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.up * -Mathf.Cos(GrapplingHook.aimAngle) / 50, ForceMode2D.Impulse);
                rb.AddForce(Vector2.right * Mathf.Sin(GrapplingHook.aimAngle) / 50, ForceMode2D.Impulse);
            }
        }
            
        
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) //stoppt den player langsam
        {
            rb.AddForce(Vector2.right * -rb.velocity.x / 50, ForceMode2D.Impulse);

        }
    }

    public bool isWallRight()
    {
        return !Physics2D.BoxCast(transform.position, boxSizeH, 0, transform.right, castDistanceH, groundLayer) || GrapplingHook.ropeAttached;
    }

    public bool isWallLeft()
    {
        return !Physics2D.BoxCast(transform.position, boxSizeH, 0, -transform.right, castDistanceH, groundLayer) || GrapplingHook.ropeAttached;
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSizeV, 0, -transform.up, castDistanceV, groundLayer);
    }

    void Start()
    {
        
    }
}
