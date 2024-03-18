using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hookSpeed = 10f; // Speed at which the player moves towards the hooked position
    public LayerMask obstacleLayer; // Layer mask for obstacles

    private bool isHooking = false;
    private Vector2 hookTarget;

    void Update()
    {
        // Check for mouse click to trigger hook
        if (Input.GetMouseButtonDown(0))
        {
            StartHook();
        }

        // Move towards the hooked position if hooking
        if (isHooking)
        {
            MoveTowardsHook();
        }
    }

    void StartHook()
    {
        // Calculate direction from player to mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Cast a ray to find the nearest obstacle
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, obstacleLayer);
        
        if (hit.collider != null)
        {
            // Set hook target to the point where the ray hits the obstacle
            hookTarget = hit.point;
            isHooking = true;
        }
    }

    void MoveTowardsHook()
    {
        // Move the player towards the hook target
        transform.position = Vector2.MoveTowards(transform.position, hookTarget, hookSpeed * Time.deltaTime);

        // Stop hooking when player reaches the hook target
        if (Vector2.Distance(transform.position, hookTarget) < 0.1f)
        {
            isHooking = false;
        }
    }
}