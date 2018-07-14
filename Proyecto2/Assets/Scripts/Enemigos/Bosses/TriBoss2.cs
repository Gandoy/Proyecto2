using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBoss2 : TriBoss {

    void Start()
    {

        CC = GetComponent<CharacterController>();
        PS = Player.PlayerSingleton;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        switch (State)
        {
            case 1:
                {
                    Charge();
                    break;
                }
            case 2:
                {
                    if (Unstuntime < Time.time)
                    {
                        ReadyForCharge();
                        HorizontalSpeed = MaxSpeed;
                    }
                    break;
                }
        }
        Vector3 movement = transform.forward * HorizontalSpeed;
        movement += new Vector3(0, Gravity, 0);
        CC.Move(movement * Time.deltaTime);

    }
    protected override void Charge()
    {
        if(HorizontalSpeed>0)
        HorizontalSpeed -= Accel * Time.deltaTime;
        else
        {
            Getstunned();
        }
    }
    public override void TeleportTo(int index)
    {
        transform.position = PlacesToTeleport[index].position;
        transform.Rotate(0, 180, 0);
    }
    public override void Getstunned()
    {
        anim.SetBool("Charge", false);
        State = 2;
        Unstuntime = Time.time + StunTime;
        HorizontalSpeed = 0;
    }
}
