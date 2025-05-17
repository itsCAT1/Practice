using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryCatchExample : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        //rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rigid.velocity.y);
    }
    void Start()
    {
        try
        {
            rigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rigid.velocity.y);
        }
        catch(System.Exception e) 
        {
            Debug.Log(e.Message);
        }
    }
}
