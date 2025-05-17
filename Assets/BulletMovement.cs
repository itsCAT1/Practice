using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        this.transform.position += this.transform.right * speed * Time.deltaTime;
    }

    
    Coroutine _deactiveWait = null;

    private void OnEnable()
    {
        _deactiveWait = StartCoroutine(DeactiveAfterTime());
    }

    private void OnDisable()
    {
        if( _deactiveWait != null)
        {
            StopCoroutine(_deactiveWait);
            _deactiveWait = null;
        }
    }

    IEnumerator DeactiveAfterTime()
    {
        yield return new WaitForSeconds(2);
        
        this.gameObject.SetActive(false);
    }
}
