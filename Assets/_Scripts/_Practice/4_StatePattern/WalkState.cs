using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class WalkState : State
{
    private PlayerController controller;
    private PlayerAnimation animation;

    public WalkState(PlayerController control, PlayerAnimation anim)
    {
        controller = control;
        animation = anim;
    }

    protected override void OnStateEnter(State from, object data)
    {
        animation.SetMoving(true);
        
    }

    protected override void OnStateUpdate()
    {
        FlipCharacter();
        
    }

    protected override void OnStateFixedUpdate()
    {
        MoveByTranform();
    }

    public void MoveByTranform()
    {
        float inputX = controller.GetHorizontalInput();

        var position = controller.transform.position;
        position.x += inputX * controller.speedMove * Time.deltaTime;
        controller.transform.position = position;
    }

    void FlipCharacter()
    {
        float inputX = controller.GetHorizontalInput();
        if (inputX < 0) controller.transform.localScale = new Vector3(-1, 1, 1);
        if (inputX > 0) controller.transform.localScale = new Vector3(1, 1, 1);
    }

    protected override void OnStateExit(State to)
    {
    }

}
