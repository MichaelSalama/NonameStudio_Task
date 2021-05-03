using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    [SerializeField] protected SV_PlayerManager playerManager = null;


    private BoxCollider2D _collider;

    [Space]
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float raycastOffset = 0.01f;
    [SerializeField] private float thresholdAngle = 15f;

    //[SerializeField]
    //Collider2D floorCollider;

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
        Vector2 size = new Vector2(raycastOffset, _collider.size.y);

        Vector2 originR = new Vector2(transform.position.x + _collider.bounds.extents.x, transform.position.y);
        RaycastHit2D rightHitInfo;
        rightHitInfo = Physics2D.BoxCast(originR, size, 0, Vector2.right, raycastOffset, layerMask);
        if (rightHitInfo)
        {
            float slopeAngleR = Vector2.Angle(rightHitInfo.normal, Vector2.up);
            if (slopeAngleR < thresholdAngle)
            {
                playerManager.IsOnSlope = true;
                playerManager.GroundNormal = rightHitInfo.normal;
            }
            else
            {
                playerManager.CanMoveRight = false;
                playerManager.CanMoveLeft = true;
            }
        }

        Vector2 originL = new Vector2(transform.position.x - _collider.bounds.extents.x, transform.position.y);
        RaycastHit2D leftHitInfo;
        leftHitInfo = Physics2D.BoxCast(originL, size, 0, Vector2.left, raycastOffset, layerMask);
        if (leftHitInfo)
        {
            float slopeAngleL = Vector2.Angle(leftHitInfo.normal, Vector2.up);
            if (slopeAngleL < thresholdAngle)
            {
                playerManager.IsOnSlope = true;
                playerManager.GroundNormal = leftHitInfo.normal;
            }
            else
            {
                playerManager.CanMoveLeft = false;
                playerManager.CanMoveRight = true;
            }
        }

        if (!rightHitInfo && !leftHitInfo)
            playerManager.CanMoveLeft = playerManager.CanMoveRight = true;
    }

    void GroundCheck()
    {
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - _collider.bounds.extents.y);
        Vector2 size = new Vector2(_collider.size.x, raycastOffset);

        RaycastHit2D buttomHitInfo;
        buttomHitInfo = Physics2D.BoxCast(origin, size, 0, Vector2.down, raycastOffset, layerMask);
        if (buttomHitInfo)
            playerManager.IsGrounded = true;
        else
            playerManager.IsGrounded = playerManager.IsOnSlope= false;


         //Using Collider.Intersects

        //if (_collider.bounds.Intersects(floorCollider.bounds))
        //{
        //    playerManager.IsGrounded = true;
        //    transform.position = new Vector2(transform.position.x, (floorCollider.bounds.max.y + _collider.bounds.extents.y));
        //}
        //else
        //    playerManager.IsGrounded = false;
    }
}
