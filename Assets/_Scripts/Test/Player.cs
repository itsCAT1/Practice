using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float angleOffset = 0f;
    public float speed = 5f;

    private Queue<Vector3> _listPos = new Queue<Vector3>();
    private Vector3? currentTarget;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = Camera.main.WorldToScreenPoint(this.transform.position).z;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            _listPos.Enqueue(mouseWorldPos);
        }

        if(currentTarget == null && _listPos.Count > 0)
        {
            currentTarget = _listPos.Dequeue();
        }

        if(currentTarget != null)
        {
            MoveAndRotateToTarget((Vector3)currentTarget);

            if(Vector3.Distance(this.transform.position, (Vector3)currentTarget) < 0.1f)
            {
                currentTarget = null;
            }
        }


    }

    void MoveAndRotateToTarget(Vector3 target)
    {
        // Di chuyển
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Quay hướng
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
    }
}
