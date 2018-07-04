using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloIA : Character {
    [SerializeField]
    private int State;
    [SerializeField]
    private float Gravity;
    private float VerticalForce;
    [SerializeField]
    private float HorizontalSpeed;
    private CharacterController CC;
    private Player PS;
    [SerializeField]
    private float SwitchToBallCD;
    private float LastSwitch;
    [SerializeField]
    private float QuitRollingCD;
    [SerializeField]
    private GameObject AnimContainer;
    [SerializeField]
    private RotateModel Rotator;
    
    private Animator anim;
    

    private void ChangeState (int S)
    {
        State = S;
        if (S == 1)
            anim.SetBool("Spinning", true);
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
                    Phy(PS.LeftOrRightFrom(transform.position.z));
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
    private void Phy(int HorizontalDir)
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
        CC.Move(mov * Time.deltaTime);
    }
}

