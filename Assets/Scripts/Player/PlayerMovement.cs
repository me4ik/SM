using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{

    private Rigidbody2D rb;
    private Vector2 _movementInput;
    private Vector2 _SmoothMoveInput;
    private Vector2 _MoveInputSmoothVelocity;

    public float speed = 0.5f;
    public float sprintMod = 1.5f;
    private Vector2 moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!isLocalPlayer) return;
        
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.y = Input.GetAxis("Vertical");

            _SmoothMoveInput = Vector2.SmoothDamp(_SmoothMoveInput, moveVector, ref _MoveInputSmoothVelocity, 0.1f);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = speed * sprintMod * _SmoothMoveInput;
            }
            else rb.velocity = _SmoothMoveInput * speed;
        
    }

}
