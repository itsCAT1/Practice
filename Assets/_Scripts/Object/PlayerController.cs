using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public float inputX;

    public InputActionReference move;
    public InputActionReference fire;

    private void Awake()
    {
        inputHandler = new PlayerInputHandler();

        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        bulletSpawner = new BulletSpawner(transform);
        playerAnimation = new PlayerAnimation(GetComponent<Animator>());

        

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

    private void OnEnable()
    {
        fire.action.started += Fire;
    }

    private void OnDisable()
    {
        fire.action.started -= Fire;
    }

    private void FixedUpdate()
    {
        stateMachine.FixedTick();
    }

    private void HandleInput()
    {
        inputX = move.action.ReadValue<float>();

        Debug.Log(inputX);

        if (inputX == 0)
        {
            stateMachine.ChangeState<IdleState>();
        }
        else
        {
            stateMachine.ChangeState<WalkState>();
        }

        /*if (inputHandler.IsAttackPressed())
        {
            stateMachine.ChangeState<AttackState>();
        }*/
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        Debug.Log("fire");
        bulletSpawner.Shoot();
    }

}
