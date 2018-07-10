﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compy : Character {

    [SerializeField]
    private RotateModel Rotator;
    private float VerticalForce;
    [SerializeField]
    private float HorizontalSpeed;
    [SerializeField]
    private float JumpPower;
    [SerializeField]
    private float Gravity;
    private CharacterController CC;
    private void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Phy(Player.PlayerSingleton.LeftOrRightFrom(transform.position.z));
    }

    private void Phy(int HorizontalDir)
    {
        if (HorizontalDir == 1)
        {
            Rotator.turnright();
        }
        else if (HorizontalDir == -1)
        {
            Rotator.turnleft();
        }
   
          
        Vector3 mov = Vector3.zero;
        if (!CC.isGrounded)
            VerticalForce += Gravity * Time.deltaTime;
        else
            VerticalForce += JumpPower;
        mov += Vector3.down * -VerticalForce;
        mov += Front * HorizontalDir * HorizontalSpeed;
        CC.Move(mov * Time.deltaTime);
    }
}
