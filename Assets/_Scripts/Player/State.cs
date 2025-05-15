using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    PlayerController controller;
    public IdleState(PlayerController control)
    {
        controller = control;
    }

    public void Enter()
    {
        controller.animator.SetBool("isMoving", false);
        Debug.Log("idle");
    }

    public void Execute()
    {

        
    }

    public void Exit()
    {
        
    }
}

public class RunState : IState
{
    PlayerController controller;
    public RunState(PlayerController control)
    {
        controller = control;
    }

    public void Enter()
    {
        controller.animator.SetBool("isMoving", true);
        Debug.Log("run");
    }

    public void Execute()
    {
        var inputX = Input.GetAxisRaw("Horizontal");

        var controllerPos = controller.transform.position;
        controllerPos.x += inputX * controller.speedMove * Time.deltaTime;
        controller.transform.position = controllerPos;

        if (inputX < 0) controller.transform.localScale = new Vector3(-1,1,1);
        if (inputX > 0) controller.transform.localScale = new Vector3(1, 1, 1);
    }

    public void Exit()
    {
        
    }
}

public class AttackState : IState
{
    PlayerController controller;
    public AttackState(PlayerController control)
    {
        controller = control;
    }

    public void Enter()
    {
        Debug.Log("attack");
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        
    }
}
