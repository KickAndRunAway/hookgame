using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GrapplingHook : MonoBehaviour
{
    public GameObject ropeHingeAnchor;
    public DistanceJoint2D ropeJoint;
    public Movement playerMovement;
    public bool ropeAttached = false;
    public bool goal = false;
    public float aimAngle;
    private Vector2 playerPosition;
    private Rigidbody2D ropeHingeAnchorRb;
    private SpriteRenderer ropeHingeAnchorSprite;
    public LineRenderer ropeRenderer;
    public LayerMask groundLayer;
    public float ropeMaxCastDistance = 50;
    private bool distanceSet;
    public float climbSpeed;
    private List<Vector2> ropePositions = new List<Vector2>();
    public Texture2D closeCursor;
    public Texture2D farCursor;
    private bool cursorWhite = true;
    private float timer = -3;

    private void HandleInput(Vector2 aimDirection) //alle möglichen inputs der hook
    {   
        if (Input.GetMouseButton(0)) //linker mausklick schiesst die hook
        {
            if (ropeAttached) return;
            ropeRenderer.enabled = true;

            var hit = Physics2D.Raycast(playerPosition, aimDirection, ropeMaxCastDistance, groundLayer);
        
            if (hit.collider != null && timer >= 0 && !goal) //hook trifft wand
            {
                ropeAttached = true;
                if (!ropePositions.Contains(hit.point))
                {
                    if(playerMovement.isGrounded()) //player springt ein wenig und wird dann gezogen
                    {
                        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 5), ForceMode2D.Impulse);
                    }
                    ropePositions.Add(hit.point);
                    ropeJoint.distance = Vector2.Distance(playerPosition, hit.point);
                    ropeJoint.enabled = true;
                    ropeHingeAnchorSprite.enabled = true;
                }
            }
            else
            {
                ropeRenderer.enabled = false;
                ropeAttached = false;
                ropeJoint.enabled = false;
            }
        }

        if (Input.GetMouseButtonUp(0)) //wenn man linke maustaste loslässt, wird die hook eingeholt
        {
            ResetRope();
        }
    }

    private void ResetRope() //hook reset
    {
        ropeJoint.enabled = false;
        ropeAttached = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, transform.position);
        ropePositions.Clear();
        ropeHingeAnchorSprite.enabled = false;
    }
    
    private void HandleRopeLength() //player wird zur hook gezogen
    {
        if (ropeAttached && ropeJoint.distance > 1)
        {
            ropeJoint.distance -= Time.deltaTime * climbSpeed;
        }
    }

    void Awake()
    {
        ropeJoint.enabled = false;
        playerPosition = transform.position;
        ropeHingeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
        ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
    }
    private void UpdateRopePositions() //rope vertex positionen, also beim player und der hook
    {
        if (!ropeAttached)
        {
            return;
        }

        ropeRenderer.positionCount = ropePositions.Count + 1;

        for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
        {
            if (i != ropeRenderer.positionCount - 1) 
            {
                ropeRenderer.SetPosition(i, ropePositions[i]);
                if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
                {
                    var ropePosition = ropePositions[ropePositions.Count - 1];
                    if (ropePositions.Count == 1)
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                    else
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                }
                else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
                {
                    var ropePosition = ropePositions.Last();
                    ropeHingeAnchorRb.transform.position = ropePosition;
                    if (!distanceSet)
                    {
                        ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                        distanceSet = true;
                    }
                }
            }
            else
            {
                ropeRenderer.SetPosition(i, transform.position);
            }
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        var worldMousePosition =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        var facingDirection = worldMousePosition - transform.position;
        var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
        if (aimAngle < 15)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }
        var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
        playerPosition = transform.position;

        var hit = Physics2D.Raycast(playerPosition, aimDirection, ropeMaxCastDistance, groundLayer);

        if (hit.collider != null && cursorWhite) //hook trifft wand
        {
            Cursor.SetCursor(closeCursor, Vector2.zero, CursorMode.Auto); //cursor teal wenn hook nutzbar ist, sonst cursor weiss
            cursorWhite = false;
        }
        else if (hit.collider == null && !cursorWhite)
        {
            Cursor.SetCursor(farCursor, Vector2.zero, CursorMode.Auto);
            cursorWhite = true;
        }

        HandleInput(aimDirection);
        UpdateRopePositions();
        HandleRopeLength();

    }

}
