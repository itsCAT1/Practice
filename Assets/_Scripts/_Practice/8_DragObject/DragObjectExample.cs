using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjectExample : MonoBehaviour
{
    private bool onDragging = false;
    private Vector2 offset;

    [SerializeField] float speedMove;
    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        onDragging = true;

        offset = (Vector2)transform.position - MouseWorldPosition();
    }

    private void OnMouseUp()
    {
        onDragging = false;
    }

    Vector2 MouseWorldPosition()
    {
        var mouPos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mouPos);
    }

    private void FixedUpdate()
    {
        if(onDragging)
        {
            Vector2 targetPos = MouseWorldPosition() + offset;
            rigid.MovePosition(Vector2.Lerp(this.transform.position, targetPos, speedMove * Time.fixedDeltaTime));

        }
    }
}
