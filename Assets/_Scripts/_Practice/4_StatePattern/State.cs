using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerController controller;
    private PlayerAnimation animation;

    public IdleState(PlayerController control, PlayerAnimation anim)
    {
        controller = control;
        animation = anim;
    }

    public void Enter()
    {
        animation.SetMoving(false);
        //Debug.Log("idle");
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
    private PlayerController controller;
    private PlayerAnimation animation;

    public RunState(PlayerController control, PlayerAnimation anim)
    {
        controller = control;
        animation = anim;

        
    }

    public void Enter()
    {
        animation.SetMoving(true);
    }

    public void Execute()
    {
        float inputX = controller.GetHorizontalInput();

        //MoveByTranform();
        //MoveByVelocity();
        //MoveByTranslate();
        MoveByPush();

        if (inputX < 0) controller.transform.localScale = new Vector3(-1, 1, 1);
        if (inputX > 0) controller.transform.localScale = new Vector3(1, 1, 1);
    }

    public void Exit() { }


    public void MoveByTranform()
    {
        float inputX = controller.GetHorizontalInput();

        var position = controller.transform.position;
        position.x += inputX * controller.speedMove * Time.deltaTime;
        controller.transform.position = position;
    }

    public void MoveByVelocity()
    {
        float inputX = controller.GetHorizontalInput();
        controller.rigid.velocity = new Vector2(controller.speedMove * inputX, controller.rigid.velocity.y);
    }

    public void MoveByTranslate()
    {
        float inputX = controller.GetHorizontalInput();
        controller.transform.Translate(controller.speedMove * inputX * Time.deltaTime, 0, 0);
    }

    public void MoveByPush()
    {
        float inputX = controller.GetHorizontalInput();
        var targetPos = (Vector2)controller.transform.position + inputX * Vector2.right;
        controller.transform.position = Vector2.MoveTowards(controller.transform.position, targetPos, controller.speedMove * Time.deltaTime);
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
        //Debug.Log("attack");
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        
    }
}
