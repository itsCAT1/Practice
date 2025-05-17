using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler
{
    public float GetHorizontalInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public bool IsAttackPressed()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool IsShootPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
