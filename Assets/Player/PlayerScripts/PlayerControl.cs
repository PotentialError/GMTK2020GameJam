using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour //more like out of control, am i right gamers?
{
    public float jumpForce;
    public float moveSpeed;
    public float extra = 0.1f;

    public bool WASD = true;
    public bool WEnabled = true;
    public bool AEnabled = true;
    public bool DEnabled = true;
    public bool ShootEnabled = true;

    public bool WPressed;
    public bool APressed;
    public bool DPressed;

    private Rigidbody2D rb;
    public GroundDetection gd;
    private float movement;

    public bool isGrounded = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        transform.position = GlobalData.RespawnPosition;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        WPressed = Input.GetKeyDown(KeyCode.W);
        APressed = Input.GetKeyDown(KeyCode.A);
        DPressed = Input.GetKeyDown(KeyCode.D);
        /*
        if (WPressed)
            Debug.Log("w");
        if (APressed)
            Debug.Log("a");
        if (DPressed)
            Debug.Log("d");
            */


        movement = Input.GetAxisRaw("Horizontal");
        if (isGrounded && rb.velocity.y < 0.5f && rb.velocity.y > -0.5f)
        {
            anim.SetBool("isLanded", true);
            if (movement != 0)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            anim.SetBool("isLanded", false);
        }
        if(rb.velocity.y < -0.5f)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
        if (WASD)
        {
            if (WEnabled && WPressed)
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (movement != 0)
        {
            rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void Jump()
    {
        Debug.Log("jump check 1" + IsGrounded());
        if (isGrounded && rb.velocity.y < 0.5f && rb.velocity.y > -0.5f)
        {
            Debug.Log("Jump check 2");
            anim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    bool IsGrounded()
    {
        return Physics2D.Raycast(GetComponent<BoxCollider2D>().bounds.center, Vector2.down, GetComponent<BoxCollider2D>().bounds.extents.y + extra, LayerMask.GetMask("Ground"));
    }
}
