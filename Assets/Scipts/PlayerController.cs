using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D theRB;
    public float moveSpeed;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    private bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer theSR;

    public float knockbackLength, knockbackForce;
    private float knockbackCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim=GetComponent<Animator>();
        theSR=GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (knockbackCounter <= 0)
        {

            theRB.linearVelocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.linearVelocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        theRB.linearVelocity = new Vector2(theRB.linearVelocity.x, jumpForce);
                        canDoubleJump = false;
                    }
                }
            }
            if (theRB.linearVelocity.x < 0)
            {
                theSR.flipX = true;
            }
            else if (theRB.linearVelocity.x > 0)
            {
                theSR.flipX = false;
            }
        }
        else
        {
            knockbackCounter -= Time.deltaTime;
            if(!theSR.flipX)
            {
                theRB.linearVelocity = new Vector2(-knockbackForce, knockbackForce);
            }
            else
            {
                theRB.linearVelocity = new Vector2(knockbackForce, knockbackForce);
            }
        }
            anim.SetFloat("moveSpeed", Mathf.Abs(theRB.linearVelocity.x));
            anim.SetBool("isGrounded", isGrounded);
        
    }

    public void Knockback()
    {
        knockbackCounter = knockbackLength;
        theRB.linearVelocity = new Vector2(0f, knockbackForce);
    
        anim.SetTrigger("hurt");
    }

}
