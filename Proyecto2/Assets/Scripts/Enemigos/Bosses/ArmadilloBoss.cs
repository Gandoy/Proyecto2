using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloBoss : ArmadilloIA {

    private void Start()
    {
        CC = GetComponent<CharacterController>();
        //  if (Player.PlayerSingleton == null)
        //    Debug.Log("es null");
        PS = Player.PlayerSingleton;
        anim = AnimContainer.GetComponent<Animator>();
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
                    
                        ChangeState(0);
                   
                    break;
                }
        }
    }
}
