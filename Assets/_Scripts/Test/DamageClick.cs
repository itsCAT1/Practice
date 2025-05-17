using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageClick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Damageable damageable = hit.collider.GetComponent<Damageable>();

                if (damageable != null)
                {
                    damageable.TakeDamage(1);
                }
            }
        }
    }
}
