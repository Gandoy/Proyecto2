﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlynnInput : MonoBehaviour {
    [SerializeField]
    private List<KeyCode> Weapons;
    [SerializeField]
    private Player P;
    [SerializeField]
    RotateModel Rotator;
    //esto esta para testear nomas, despues hay que hacerlo con un boton de la interfaz;
    [SerializeField]
    private KeyCode SaveB;
    [SerializeField]
    private KeyCode Left;
    [SerializeField]
    private KeyCode Right;


    public void PressedAKey(int I)
    {
        P.TakeAnyInput(I);
    }
    private void Update()
    {
        
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(SaveB))
                PowerUpController.instance.Save();
                for (int K=0; K < Weapons.Count;K++)
            {
                if (Input.GetKeyDown(Weapons[K]))
                {
                    Debug.Log("entroCambioDeArma");
                    P.TakeAnyInput(K);
                }  
            }
            if (Input.GetKeyDown(Left))
                Rotator.turnleft();
            if (Input.GetKeyDown(Right))
                Rotator.turnright();
               
        }
    }
}
