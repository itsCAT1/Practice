using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StateMachine stateMachine;
    private IdleState idleState;
    private RunState runState;
    private AttackState attackState;

    public float speedMove;
    public Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
        stateMachine = GetComponent<StateMachine>();
        idleState = new IdleState(this);
        runState = new RunState(this);
        attackState = new AttackState(this);

        stateMachine.ChangeState(idleState);
    }

    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        var inputX = Input.GetAxisRaw("Horizontal");

        if (inputX == 0)
        {
            stateMachine.ChangeState(idleState);
        }

        else
        {
            stateMachine.ChangeState(runState);
        }

        if (Input.GetMouseButtonDown(0))
        {
            stateMachine.ChangeState(attackState);
        }
    }
}
