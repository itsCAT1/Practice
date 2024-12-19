using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    PlayerController controller;
    public IdleState(PlayerController player)
    {
        controller = player;
    }

    public void Enter()
    {
        controller.PlayIdle();
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}

public class MovingState : IState
{
    PlayerController controller;
    public MovingState(PlayerController player)
    {
        controller = player;
    }

    public void Enter()
    {
        controller.PlayMove();
    }

    public void Execute()
    {
        controller.PerformMoving();
    }

    public void Exit()
    {

    }
}


public class JumpingState : IState
{
    PlayerController controller;
    public JumpingState(PlayerController player)
    {
        controller = player;
    }

    public void Enter()
    {
        controller.PlayJump();
        controller.PerformJumping();
    }

    public void Execute()
    {
        controller.PerformMoving();
        if (controller.rigid.velocity.y < 0)
        {
            controller._stateManager.ChangeState(new FallState(controller));
        }
    }

    public void Exit()
    {

    }
}

public class DoubleJumpingState : IState
{
    PlayerController controller;
    public DoubleJumpingState(PlayerController player)
    {
        controller = player;
    }

    public void Enter()
    {
        controller.PlayDoubleJump();
        controller.PerformJumping();
    }

    public void Execute()
    {
        controller.PerformMoving();
        if (controller.rigid.velocity.y < 0)
        {
            controller._stateManager.ChangeState(new FallState(controller));
        }
    }

    public void Exit()
    {

    }
}

public class FallState : IState
{
    PlayerController controller;

    public FallState(PlayerController player)
    {
        controller = player;
    }

    public void Enter()
    {
        controller.PlayFall();
    }

    public void Execute()
    {
        controller.PerformMoving();
    }

    public void Exit()
    {

    }
}

public class WallSlidingState : IState
{
    private PlayerController controller;
    private float wallSlideSpeed = 2f; 

    public WallSlidingState(PlayerController player)
    {
        controller = player;
    }

    public void Enter()
    {
        controller.PlayWallJump(); 
    }

    public void Execute()
    {
        controller.rigid.velocity = new Vector2(controller.rigid.velocity.x, Mathf.Clamp(controller.rigid.velocity.y, -wallSlideSpeed, float.MaxValue));
    }

    public void Exit()
    {
        Debug.Log("Exit Wall Sliding");
    }
}

