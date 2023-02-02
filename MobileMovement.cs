using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    public int moveDir = 0;
    public int mobileDir = 0;

    [SerializeField]
    float moveSpeed = 5.0f;
    
    Rigidbody2D rb;

	[SerializeField]
	float jumpSpeed = 1.0f;
	public bool grounded = false;
    Animator animator;
    SpriteRenderer spriteR;

	void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveDir = 0;
        int inputDir = (int)Input.GetAxisRaw("Horizontal");

        moveDir = inputDir + mobileDir;
        moveDir = Mathf.Clamp(moveDir, -1, 1);

        Vector2 velocity = rb.velocity;
        velocity.x = moveDir * moveSpeed;
        rb.velocity = velocity;

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            animator.SetTrigger("jump");
        }
        if (rb.velocity.y < -0.1f && !grounded)
        {
            animator.SetTrigger("fall");
        }

        animator.SetFloat("xInput", moveDir);
        animator.SetBool("grounded", grounded);

        if (moveDir < 0)
        {
            spriteR.flipX = true;
        }

        else if(moveDir > 0)
        {
            spriteR.flipX = false;
        }
        if(mobileDir < 0)
        {
            spriteR.flipX = true;
        }
        else if(mobileDir > 0)
        {
            spriteR.flipX = false;
        }

        float xInput = Input.GetAxis("Horizontal");
        GetComponent<Animator>().SetFloat("xInput", xInput);
	}

    public void UpdateMoveDirection(int direction)
    {
        mobileDir = direction;
    }

    public void Jump()
    {
        if (grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            grounded = false;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			grounded = false;
		}
	}
}
