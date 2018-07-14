using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloIA : Character {
    [SerializeField]
    protected int State;
    [SerializeField]
    protected float Gravity;
    protected float VerticalForce;
    [SerializeField]
    protected float HorizontalSpeed;
    protected CharacterController CC;
    protected Player PS;
    [SerializeField]
    protected float SwitchToBallCD;
    protected float LastSwitch;
    [SerializeField]
    protected float QuitRollingCD;
    [SerializeField]
    protected GameObject AnimContainer;
    [SerializeField]
    private RotateModel Rotator;
    protected int D;


    protected Animator anim;
    

    protected void ChangeState (int S)
    {
        State = S;
        if (S == 1)
        {
            anim.SetBool("Spinning", true);
            D = PS.LeftOrRightFrom(transform.position.z);
        }
           
        else
            anim.SetBool("Spinning", false);
    }
    private void Start()
    {
        CC = GetComponent<CharacterController>();
      //  if (Player.PlayerSingleton == null)
        //    Debug.Log("es null");
        PS = Player.PlayerSingleton;
        anim = AnimContainer.GetComponent<Animator>();
    }
    protected override void Death()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        switch (State)
        {
            case 0:
                {
                    if (Time.time > LastSwitch + SwitchToBallCD)
                    {
                        ChangeState(1);
                        LastSwitch = Time.time;
                    }
                  
                    if (PS.UpOrDown(transform.position.y) != 0)
                    {
                        ChangeState(2);
                    }

                    //aca manda la idle animation
                    break;
                }
            case 1:
                {
                    if (Time.time > LastSwitch + QuitRollingCD)
                    {
                        ChangeState(0);
                        LastSwitch = Time.time;
                    }
                        
                    //aca hacelo girar
                    Phy(D);
                    break;
                }
            case 2:
                {
                    if(PS.UpOrDown(transform.position.y)==0)
                    {
                        ChangeState(0);
                    }
                    break;
                }
        }
    }
    protected void Phy(int HorizontalDir)
    {
        if (HorizontalDir==1)
        {
            Rotator.turnright();
        }
        else if (HorizontalDir==-1)
        {
            Rotator.turnleft();
        }
        Vector3 mov = Vector3.zero;
        mov += Vector3.down * -VerticalForce;
        mov += Front * HorizontalDir *HorizontalSpeed;
        //gravedad
        if (!CC.isGrounded)
        mov += new Vector3(0, Gravity, 0);
        CC.Move(mov * Time.deltaTime);
      

    }
    
}

