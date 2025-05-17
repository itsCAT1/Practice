using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState currentState;

    public void ChangeState(IState state)
    {
        if(currentState != null && currentState == state)
        {
            return;
        }

        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}
