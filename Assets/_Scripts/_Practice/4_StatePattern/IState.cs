using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Exit();

    public void Enter();

    public void Execute();
}
