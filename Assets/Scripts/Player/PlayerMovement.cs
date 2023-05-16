using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector2 _movementInput;
    private Vector2 _SmoothMoveInput;
    private Vector2 _MoveInputSmoothVelocity;

    public float speed = 0.5f;
    private Vector2 moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        _SmoothMoveInput = Vector2.SmoothDamp(_SmoothMoveInput,moveVector, ref _MoveInputSmoothVelocity, 0.1f);

        rb.velocity = _SmoothMoveInput * speed;



        //moveVector.x = Input.GetAxis("Horizontal");
        //moveVector.y = Input.GetAxis("Vertical");

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    speed = 10;
        //}       

        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);

        //speed = 6;
    }

}
