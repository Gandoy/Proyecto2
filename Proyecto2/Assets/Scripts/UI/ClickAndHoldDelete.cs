using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickAndHoldDelete : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private float HoldTime;
    public UnityEvent OnLongClick;
    private bool pointerdown;
    private float heldtimer;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("button down");
        pointerdown = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        reset();
    }
    private void reset()
    {
        Debug.Log("reset");
        pointerdown = false;
        heldtimer = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(pointerdown)
        {
            heldtimer += Time.deltaTime;
            if(heldtimer>HoldTime)
            {
                Debug.Log("entro al held");
                if (OnLongClick != null)
                    OnLongClick.Invoke();
                reset();
            }
        }
    }
}
