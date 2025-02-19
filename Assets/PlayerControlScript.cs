using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpForce = 10f;

    private Vector2 _moveDiretion;

    private float _airSpeed;
    public InputActionReference move;
    public InputActionReference jump;

    bool isGrounded() { return rb.linearVelocity.y == 0;}
    bool isJumping () { return jump.action.inProgress;}

    // Update is called once per frame
    void Update()
    {  
        _moveDiretion = move.action.ReadValue<Vector2>();
        
      if (isGrounded())
      {

        if (isJumping())
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            
            _airSpeed = rb.linearVelocityX;
            _moveDiretion.x = _airSpeed;    
        }
      }
    }
    void FixedUpdate()
    {
       if (isGrounded())
       {
        rb.linearVelocity = new Vector2(x: _moveDiretion.x * moveSpeed, y: rb.linearVelocityY);
       }else
       {
        rb.linearVelocity = new Vector2(x: rb.linearVelocityX, y: rb.linearVelocityY);
       }
    }
    
}
