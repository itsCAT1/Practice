using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour
{
    public Vector3 offset;
    private Rigidbody2D rigid;
    private bool isDragging = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        isDragging = true;

        offset = transform.position - MouseWorldPosition();
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    Vector3 MouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 targetPos = MouseWorldPosition() + offset;
            rigid.MovePosition(Vector2.Lerp(rigid.position, targetPos, 50 * Time.fixedDeltaTime));
        }
    }
}
