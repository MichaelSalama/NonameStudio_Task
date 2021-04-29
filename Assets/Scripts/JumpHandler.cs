using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler : MonoBehaviour
{
    [SerializeField] protected SV_PlayerManager playerManager = null;
    [SerializeField] protected SV_PlayerStats playerStats = null;

    protected MovePlayerInput movePlayerInput = null;

    void Start()
    {
        movePlayerInput = GetComponent<MovePlayerInput>();

    }

    void FixedUpdate()
    {
        Jump();

    }



    void Jump()
    {
        if (!playerManager.IsGrounded) return;

        if (movePlayerInput.input.jumpKeyDown)
        {

            transform.Translate(playerStats.movementStats.currentGravity * Vector2.up * Time.deltaTime);
        }
        if (movePlayerInput.input.jumpKeyHeldDown)
        {
            print("should move up");

            transform.Translate(playerStats.movementStats.currentGravity * Vector2.up * Time.deltaTime);
        }

     
            playerManager.IsGrounded = false;
        
    }
}
