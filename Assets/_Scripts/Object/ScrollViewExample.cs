using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewExample : MonoBehaviour
{
    ScrollRect scroll;

    [SerializeField] private Vector2 onValueChange;

    void Start()
    {
        scroll.onValueChanged.AddListener(OnScrollValueChanged);
    }

    void OnScrollValueChanged(Vector2 value) 
    {
        onValueChange = value;
    }

    void OnValidate()
    {
        scroll = GetComponent<ScrollRect>();

        scroll.normalizedPosition = onValueChange;
    }
}
