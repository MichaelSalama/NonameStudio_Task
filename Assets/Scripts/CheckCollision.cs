using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [SerializeField] protected SV_PlayerManager playerManager = null;

    [SerializeField]
    Collider2D floorCollider;

    private BoxCollider2D _collider;

    [Space]
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float raycastOffset = 0.01f;

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        GroundCheck();
        CollisionCheck();
    }

    void CollisionCheck()
    {
        Vector2 size = new Vector2(raycastOffset ,_collider.size.y);
        Vector2 originR = new Vector2(transform.position.x + _collider.bounds.extents.x, transform.position.y);

        RaycastHit2D rightHitInfo;
        rightHitInfo = Physics2D.BoxCast(originR, size, 0, Vector2.right, raycastOffset, layerMask);
        if (rightHitInfo)
        {
            playerManager.CanMoveRight = false;
            playerManager.CanMoveLeft = true;
        }

        Vector2 originL = new Vector2(transform.position.x - _collider.bounds.extents.x, transform.position.y);
        RaycastHit2D leftHitInfo;
        leftHitInfo = Physics2D.BoxCast(originL, size, 0, Vector2.left, raycastOffset, layerMask);
        if (leftHitInfo)
        {
            playerManager.CanMoveLeft = false;
            playerManager.CanMoveRight = true;
        }

        if (!rightHitInfo && !leftHitInfo)
            playerManager.CanMoveLeft = playerManager.CanMoveRight = true;
    }

    void GroundCheck()
    {
        if (_collider.bounds.Intersects(floorCollider.bounds))
        {
            playerManager.IsGrounded = true;
            transform.position = new Vector2(transform.position.x, (floorCollider.bounds.max.y + _collider.bounds.extents.y));
        }
        else
            playerManager.IsGrounded = false;
    }



    //void CheckPosition(GameObject obj)
    //{
    //    float x;
    //    x = transform.position.x - obj.transform.position.x;
    //    if (x > 0)
    //    {
    //        playerManager.CanMoveRight = false;
    //        playerManager.CanMoveLeft = true;
    //    }
    //    else if (x < 0)
    //    {

    //        playerManager.CanMoveLeft = true;
    //        playerManager.CanMoveRight = false;
    //    }
    //}
}
