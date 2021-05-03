using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] protected SV_PlayerManager playerManager = null;
    [SerializeField] protected SV_PlayerStats playerStats = null;

    protected MovePlayerInput movePlayerInput = null;

    protected float accRatePerSec;
    protected float decRatePerSec;
    protected float gravityPerSec;

    private void Start()
    {
        movePlayerInput = GetComponent<MovePlayerInput>();

        accRatePerSec = playerStats.movementStats.maxSpeed / playerStats.movementStats.timeZeroToMax;
        decRatePerSec = (playerStats.movementStats.maxSpeed * -1f) / playerStats.movementStats.timeMaxToZero;
        playerStats.movementStats.SetCurrentSpeed(0f);

        gravityPerSec = playerStats.movementStats.maxGravity / playerStats.movementStats.GravityTime;
        playerStats.movementStats.SetCurrentGravity(0f);

        playerManager.CanMoveRight = playerManager.CanMoveLeft = true;

    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        HandleGroundMovement();
        HandleVerticleMovement();
    }

    protected void HandleGroundMovement()
    {
        //if (playerManager.IsOnSlope) return;

        Vector2 dir;
        float right;
        float left;

        if (playerManager.CanMoveRight)
            right = movePlayerInput.input.rightAxis;
        else
            right = 0;

        if (playerManager.CanMoveLeft)
            left = movePlayerInput.input.leftAxis;
        else left = 0;


        float slopeAngle = Vector2.Angle(playerManager.GroundNormal, Vector2.up);
        print(slopeAngle);

        float y = Mathf.Abs(Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * (right + left));
        float x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * (right + left);
        dir = new Vector2(x, y);

                                                 // find a way to smooth the downmovement!

        if (movePlayerInput.input.IsDirectionKeyDown())
        {
            playerManager.IsDecelerate = false;

            playerStats.movementStats.SetCurrentSpeed(playerStats.movementStats.currentSpeed + accRatePerSec * Time.deltaTime); ;
            playerStats.movementStats.SetCurrentSpeed(Mathf.Min(playerStats.movementStats.currentSpeed, playerStats.movementStats.maxSpeed));
        }

        else if (!movePlayerInput.input.IsDirectionKeyDown())
            Decelerate();

        transform.Translate(playerStats.movementStats.currentSpeed * dir * Time.deltaTime);
    }

    protected void Decelerate()
    {
        playerManager.IsDecelerate = true;

        playerStats.movementStats.SetCurrentSpeed(playerStats.movementStats.currentSpeed + decRatePerSec * Time.deltaTime); ;
        playerStats.movementStats.SetCurrentSpeed(Mathf.Max(playerStats.movementStats.currentSpeed, 0));
    }

    protected void HandleVerticleMovement()
    {
        if (playerManager.IsGrounded || playerManager.IsOnSlope) return;

        playerStats.movementStats.SetCurrentGravity(playerStats.movementStats.currentGravity + gravityPerSec * Time.deltaTime);
        playerStats.movementStats.SetCurrentGravity(Mathf.Min(playerStats.movementStats.currentGravity, playerStats.movementStats.maxGravity));
        transform.Translate(playerStats.movementStats.currentGravity * Vector2.down * Time.deltaTime);
    }
}

