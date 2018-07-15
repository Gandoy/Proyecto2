using System;
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
    public bool LeftDown;
    public bool RightDown;
    public bool DownDown;
    public bool ShootDown;
    public bool JumpDown;
    private int WeaponIndex;
    public static FlynnInput instance;

    private void Awake()
    {
        instance = this;
    }


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
                   // Debug.Log("entroCambioDeArma");
                    P.TakeAnyInput(K);
                }  
            }
            if (Input.GetKeyDown(Left)||LeftDown)
                Rotator.turnleft();
            if (Input.GetKeyDown(Right)||RightDown)
                Rotator.turnright();
               
        }
    }
    public void LD()
    {
        //Debug.Log("heyheyhey");
        LeftDown = true;
    }
    public void LR()
    {
        LeftDown = false;
    }
    public void RD()
    {
        RightDown = true;
    }
    public void RR()
    {
        RightDown = false;
    }
    public void SD()
    {
        ShootDown = true;
    }
    public void SR()
    {
        ShootDown = false;
    }
    public void DD()
    {
        DownDown = true;
    }
    public void DR()
    {
        DownDown = false;
    }
    public void JD()
    {
        JumpDown = true;
    }
    public void JR()
    {
        JumpDown = false;
    }
    public void ChangeW()
    {
        WeaponIndex++;
        WeaponIndex = WeaponIndex % Weapons.Count;
        P.TakeAnyInput(WeaponIndex);
    }
}
