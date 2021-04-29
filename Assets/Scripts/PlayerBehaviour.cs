using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    private bool _isGrounded;

    [SerializeField]
    private float _jumpSpeed = 10.0f;
    [SerializeField]
    private float _gravity = 9.8f;

    void Start()
    {
        _isGrounded = true;
    }

    void Update()
    {
        //PlayerMovement();
        MovePlayer(new Vector2(Input.GetAxis("Horizontal"), 0));
    }

    private void MovePlayer( Vector2 direction)
    {
        //if (collisionflag) return;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * _speed * Time.deltaTime);
    }
}
