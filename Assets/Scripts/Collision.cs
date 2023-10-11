using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Collision")]
    public float collisionRadius = 0.55f;
    public Vector2 bottomOffset = new Vector2(0, -0.3f);
    public Vector2 rightOffset = new Vector2(0.3f, 0);
    public Vector2 leftOffset = new Vector2(-0.3f, 0);
    public Color debugCollisionColor = Color.green;
    public LayerMask groundLayer = 3;

    public bool onGround, onWall, onRightWall, onLeftWall;

    void Start()
    {
        
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        onWall = onRightWall || onLeftWall;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = onGround ? Color.blue : debugCollisionColor;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.color = onGround ? Color.blue : debugCollisionColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.color = onRightWall ? Color.blue : debugCollisionColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.color = onLeftWall ? Color.blue : debugCollisionColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }
}
