using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private PlayerController controller;
    private PlayerAnimation animation;

    public IdleState(PlayerController control, PlayerAnimation anim)
    {
        controller = control;
        animation = anim;
    }

    protected override void OnStateEnter(State from, object data)
    {
        animation.SetMoving(false);
    }

    protected override void OnStateUpdate()
    {

        Debug.Log("idle");
    }

    protected override void OnStateFixedUpdate()
    {
    }

    protected override void OnStateExit(State to)
    {
    }
}
