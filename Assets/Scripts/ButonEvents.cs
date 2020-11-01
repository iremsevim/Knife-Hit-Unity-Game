using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButonEvents : MonoBehaviour
{

    public UnityEvent OnClicked;

    public void OnMouseUpAsButton()
    {
        OnClicked?.Invoke();
    }
}
