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

// if(GrapplingHook.ropeAttached()) should check if the player is hanging

    void Update()
    {

        if (isGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A) && isWallLeft())
        {
            transform.Translate(Vector2.right * -MovementSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) && isWallRight())
        {
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
        }
    }

    public bool isWallRight()
    {
        if(Physics2D.BoxCast(transform.position, boxSizeH, 0, transform.right, castDistanceH, groundLayer)||GrapplingHook.ropeAttached)
        {
            return false;
        }
        {
            return true;
        }   
    }

    public bool isWallLeft()
    {
        if(Physics2D.BoxCast(transform.position, boxSizeH, 0, -transform.right, castDistanceH, groundLayer)||GrapplingHook.ropeAttached)
        {
            return false;
        }
        {
            return true;
        }
    }

    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSizeV, 0, -transform.up, castDistanceV, groundLayer))
        {
            return true;
        }
        {
            return false;
        }
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
