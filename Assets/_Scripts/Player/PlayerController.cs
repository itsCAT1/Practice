using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StateManager _stateManager;
    public Rigidbody2D rigid;
    Animator animator;

    public float inputHorizontal;
    public float moveSpeed;

    bool onGround = false;
    public float jumpForce;
    bool hasDoubleJump;

    void Awake()
    {
        _stateManager = GetComponent<StateManager>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        _stateManager.ChangeState(new IdleState(this));
    }

    void Update()
    {
        CheckInput();
        FlipCharactor();
    }

    void CheckInput()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (onGround)
        {
            if (inputHorizontal != 0)
            {
                _stateManager.ChangeState(new MovingState(this));
            }
            else
            {
                _stateManager.ChangeState(new IdleState(this));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                _stateManager.ChangeState(new JumpingState(this));
                hasDoubleJump = false;
                onGround = false;
            }
            else if (!hasDoubleJump)
            {
                _stateManager.ChangeState(new DoubleJumpingState(this));
                hasDoubleJump = true;
            }
        }
    }

    void FlipCharactor()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal > 0) this.transform.localScale = new Vector3(1, 1, 1);
        else if (inputHorizontal < 0) this.transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    public void PerformMoving()
    {
        this.transform.position += new Vector3(inputHorizontal * moveSpeed * Time.deltaTime, 0, 0);
    }

    public void PlayIdle()
    {
        animator.Play("Idle");
    }

    public void PlayMove()
    {
        animator.Play("Move");
    }

    public void PerformJumping()
    {
        this.rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
    }

    public void PlayJump()
    {
        animator.Play("Jump");
    }

    public void PlayDoubleJump()
    {
        animator.Play("DoubleJump");
    }

    public void PlayFall()
    {
        animator.Play("Fall");
    }
}
