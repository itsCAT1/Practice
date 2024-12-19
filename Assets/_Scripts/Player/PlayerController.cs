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

    public float jumpForce;
    bool hasDoubleJump;

    public LayerMask wallLayer;
    public Transform wallCheckPos;
    public LayerMask groundLayer;
    public Transform groundCheckPos;
    public float radius;

    bool IsGround() => Physics2D.Raycast(groundCheckPos.position, -transform.up, 0.1f, groundLayer);
    bool IsWall() => Physics2D.OverlapCircle(wallCheckPos.position, radius, wallLayer);

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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(wallCheckPos.position, radius);
        Gizmos.DrawLine(groundCheckPos.position, groundCheckPos.position + new Vector3(0,-radius,0));
    }

    void CheckInput()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        
        if (IsGround())
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

        else
        {
            if (IsWall() && !IsGround() && inputHorizontal != 0)
            {
                _stateManager.ChangeState(new WallSlidingState(this));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGround())
            {
                _stateManager.ChangeState(new JumpingState(this));
                hasDoubleJump = false;
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

    public void PlayWallJump()
    {
        animator.Play("WallJump");
    }
}
