using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler
{
    

    public bool IsAttackPressed()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool IsShootPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
