using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEvent : MonoBehaviour
{
    public DelegateExample delegateExample;

    public ActionExample actionExample;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            delegateExample.say("Unity");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            actionExample.say("Unity");
        }
    }
}
