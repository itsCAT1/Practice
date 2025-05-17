using UnityEngine;

public class DragWithPhysics : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera cam;
    private bool isDragging = false;
    private Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        isDragging = true;

        Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.WorldToScreenPoint(transform.position).z));
        offset = transform.position - mouseWorld;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.WorldToScreenPoint(transform.position).z));
            Vector3 targetPosition = mouseWorld + offset;

            rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, 10 * Time.fixedDeltaTime));
        }
    }
}
