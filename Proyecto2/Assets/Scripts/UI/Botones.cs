using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

public class Botones : MonoBehaviour, IPointerDownHandler,IPointerUpHandler {

    public UnityEvent Down;
    public UnityEvent Release;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("heyhey");
        Down.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Release.Invoke();
    }
    private void Start()
    {
        Debug.Log("existe");
    }


}
