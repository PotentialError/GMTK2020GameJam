using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour //more like out of control, am i right gamers?
{
    public float jumpForce;
    public float moveForce;

    public bool WASD = true;
    public bool WEnabled = true;
    public bool AEnabled = true;
    public bool DEnabled = true;
    public bool ShootEnabled = true;

    private bool WPressed;
    private bool APressed;
    private bool DPressed;

    private Rigidbody2D rb;
    public GroundDetection gd;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        WPressed = Input.GetKeyDown(KeyCode.W);
        APressed = Input.GetKeyDown(KeyCode.A);
        DPressed = Input.GetKeyDown(KeyCode.D);
    }

    private void FixedUpdate()
    {
        if (WASD)
        {
            if (WEnabled && WPressed)
            {
                Jump();
            }
            if (AEnabled && APressed)
            {
                MoveLeft();
            }
            if (DEnabled && DPressed)
            {
                MoveRight();
            }
        }
        
    }

    private void Jump()
    {
        if(gd.onGround && rb.velocity.y < 0.5f && rb.velocity.y > -0.5f)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void MoveLeft()
    {
        rb.AddForce(new Vector2(-moveForce, 0f));
    }

    private void MoveRight()
    {
        rb.AddForce(new Vector2(moveForce, 0f));
    }
    
}
