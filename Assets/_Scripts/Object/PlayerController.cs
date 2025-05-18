using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedMove;
    public Rigidbody2D rigid;

    private PlayerInputHandler inputHandler;
    private BulletSpawner bulletSpawner;
    private PlayerAnimation playerAnimation;

    public StateMachine stateMachine;

    PlayerMoveByDotween moveByDotween;

    public Action action = null;


    void Start()
    {
        inputHandler = new PlayerInputHandler();
        bulletSpawner = new BulletSpawner(transform);
        playerAnimation = new PlayerAnimation(GetComponent<Animator>());

        rigid = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
        stateMachine.InitStates(new List<State>
        {
            new IdleState(this, playerAnimation),
            new WalkState(this, playerAnimation),
            new AttackState(),
        });

        moveByDotween = GetComponent<PlayerMoveByDotween>();

        action = () => { bulletSpawner.Shoot(); };
        action += () => { Debug.Log("jump"); };
    }


        void Update()
    {
        stateMachine.Tick();
        HandleInput();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedTick();
    }

    private void HandleInput()
    {
        float inputX = inputHandler.GetHorizontalInput();

        if (inputX == 0)
        {
            stateMachine.ChangeState<IdleState>();
        }
        else
        {
            stateMachine.ChangeState<WalkState>();
        }

        if (inputHandler.IsAttackPressed())
        {
            stateMachine.ChangeState<AttackState>();
        }

        if (inputHandler.IsShootPressed())
        {
            bulletSpawner.Shoot();
        }
    }

    public float GetHorizontalInput()
    {
        return inputHandler.GetHorizontalInput();
    }

}
