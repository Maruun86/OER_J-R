using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpForce = 10f;

    private Vector2 _moveDiretion;

    private float airSpeed;
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
            Debug.Log("Trying to Jump");
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            
            airSpeed = rb.linearVelocityX;
            _moveDiretion.x = airSpeed;    
        }
      }else 
      {
        //In air half movements
        
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
