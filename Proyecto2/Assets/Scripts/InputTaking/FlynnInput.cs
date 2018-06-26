using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlynnInput : MonoBehaviour {
    [SerializeField]
    private List<KeyCode> Weapons;
    [SerializeField]
    private Player P;
    private void Update()
    {
        if (Input.anyKey)
        {
            for (int K=0; K < Weapons.Count;K++)
            {
                if (Input.GetKeyDown(Weapons[K]))
                {
                    Debug.Log("entroCambioDeArma");
                    P.TakeAnyInput(K);
                }
                   
            }
            
        }
    }
}
