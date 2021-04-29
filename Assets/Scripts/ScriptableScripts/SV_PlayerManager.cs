using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerManager_Name", menuName = "Scriptables/Managers/PlayerManager")]
public class SV_PlayerManager : ScriptableObject
{
    [Space]
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private bool _isInJump = false;
    [SerializeField] private bool _isSliding = false;
    [SerializeField] private bool _isDecelerate = false;
    [Space]
    [SerializeField] private Vector2 _groundNormal = Vector2.zero;
    [Space]
    [SerializeField] private bool _canMoveRight = true;
    [SerializeField] private bool _canMoveLeft = true;

    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
    public bool IsInJump { get => _isInJump; set => _isInJump = value; }
    public bool IsSliding { get => _isSliding; set => _isSliding = value; }
    public bool IsDecelerate { get => _isDecelerate; set => _isDecelerate = value; }
    public bool CanMoveRight { get => _canMoveRight; set => _canMoveRight = value; }
    public bool CanMoveLeft { get => _canMoveLeft; set => _canMoveLeft = value; }


    public Vector2 GroundNormal { get => _groundNormal; set => GroundNormal = value; }



}
