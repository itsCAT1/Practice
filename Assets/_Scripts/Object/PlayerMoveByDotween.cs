using DG.Tweening;
using System;
using UnityEngine;

public class PlayerMoveByDotween : MonoBehaviour
{
    private Tween moveTween;
    PlayerController controller;

    

    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            moveTween = this.transform.DOMoveX(2, 0.5f, false).OnComplete(() =>
            {
                controller.action?.Invoke();
            });
        }
        
    }
}
