using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // if(GrapplingHook.ropeAttached()) should check if the player is hanging

    void Update()
    {

        if (isGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        else

        if (Input.GetKey(KeyCode.A) && isWallLeft() && rb.velocity.x > -maxSpeed)
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

        else if (Input.GetKey(KeyCode.D) && isWallRight() && rb.velocity.x < maxSpeed)
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

        if (GrapplingHook.ropeAttached)
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
            
        
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.right * -rb.velocity.x / 50, ForceMode2D.Impulse);

        }
        //speed = rb.velocity.x;
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistanceV, boxSizeV);
        Gizmos.DrawWireCube(transform.position + transform.right * castDistanceH, boxSizeH);
        Gizmos.DrawWireCube(transform.position - transform.right * castDistanceH, boxSizeH);
    }


    void Start()
    {
        
    }
}
