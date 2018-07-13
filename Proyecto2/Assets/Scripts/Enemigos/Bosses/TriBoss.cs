using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBoss : Triceratops {

    [SerializeField]
    private List<Transform> PlacesToTeleport;
    [SerializeField]
    private float TimeBeforeWalk;
    [SerializeField]
    private float WalkSpeed;
    [SerializeField]
    private float WalkTime;
    [SerializeField]
    private float TimeBeforeCharge;


    public void TeleportTo(int index)
    {
        State = 2;
        GetWalking();
        transform.position = PlacesToTeleport[index].position;
        transform.Rotate(0, 180, 0);
    }
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
                   
                    break;
                }
        }
        Vector3 movement = transform.forward * HorizontalSpeed;
        movement += new Vector3(0, Gravity, 0);
        CC.Move(movement * Time.deltaTime);
        
    }
    protected override void StandBy()
    {
        Invoke("GetWalking", TimeBeforeWalk);
    }
    public void GetWalking()
    {
        HorizontalSpeed = WalkSpeed;
        Invoke("Stop", WalkTime);
    }
    public void Stop()
    {
        HorizontalSpeed = 0;
        Invoke("ReadyForCharge", TimeBeforeCharge);
        anim.SetBool("Charge", false);
    }
    protected override void ReadyForCharge()
    {
        anim.SetBool("Charge", true);
        State = 1;
    }






}
