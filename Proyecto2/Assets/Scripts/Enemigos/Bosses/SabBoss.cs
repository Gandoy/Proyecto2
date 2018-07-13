using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabBoss : Character {

    private float AirTime;
    [SerializeField]
    private float JumpPower;
    [SerializeField]
    private float Gravity;
    private float VForce;
    private CharacterController CC;
    [SerializeField]
    private Transform Target;
    private float vx;
    private Player P;
    private float Direction;
    [SerializeField]
    private Transform LeftC;
    [SerializeField]
    private Transform RightC;
    private int Jumps;
    [SerializeField]
    private int MaxJumps;

    private void Start()
    {
        P = Player.PlayerSingleton;
    }

    private void Awake()
    {
        CC = GetComponent<CharacterController>();
        AirTime = (JumpPower / Gravity) * 2;
    }

    private float VX(float Distance)
    {
        return Distance / AirTime;
    }

    private void Update()
    {
        if (CC.isGrounded)
        {
            float D;
        if (Jumps>0)
            {
               D = transform.position.z - Target.position.z;
                Jumps--;
            }
            else
            {
                Jumps = MaxJumps;
                if (P.LeftOrRightFrom(transform.position.z)==-1)
                {
                    D = transform.position.z - RightC.position.z;
                }
             else
                {
                    D = transform.position.z - LeftC.position.z;
                }

            }
               
            vx = VX(D);
            VForce = JumpPower;
            Direction = P.LeftOrRightFrom(transform.position.z);
        }
        else
            VForce -= Gravity * Time.deltaTime;
        Vector3 mov = new Vector3(0, VForce, vx*-1);
        CC.Move(mov*Time.deltaTime);
       
    }
}
