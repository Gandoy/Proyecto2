using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triceratops : Character {


    [SerializeField]
    protected int State=2;
    [SerializeField]
    protected float Gravity;
    protected float VerticalForce;
    [SerializeField]
    protected float HorizontalSpeed;
    protected CharacterController CC;
    protected Player PS;
    [SerializeField]
    protected float SightRange;
    [SerializeField]
    protected LayerMask Layers;
    [SerializeField]
    protected float ChargeDelay;
    [SerializeField]
    protected GameObject Stunner;
    [SerializeField]
    protected float StunTime;
    protected float Unstuntime;
    [SerializeField]
    protected Transform RaycastEmitter;
    protected Animator anim;
    [SerializeField]
    protected float Accel;
    [SerializeField]
    protected float MaxSpeed;

    void Start () {

        CC = GetComponent<CharacterController>();
        PS = Player.PlayerSingleton;
        anim = GetComponent<Animator>();
    }
    public virtual void Getstunned()
    {
        anim.SetBool("Charge", false);
        State = 3;
        Unstuntime = Time.time + StunTime;
        HorizontalSpeed = 0;
    }
	void Update () {
		switch(State)
        {
            case 1:
                {
                    Charge();
                    break;
                }
            case 2:
                {
                    StandBy();
                    break;
                }
            case 3:
                {
                    Stun();
                    break;
                }
            case 4:
                {
                    //preparandose para chargear;
                    break;
                }
                

        }
        Vector3 movement = transform.forward * HorizontalSpeed;
        movement += new Vector3(0, Gravity, 0);
        CC.Move(movement * Time.deltaTime);
    }
   protected virtual void Charge()
    {
        if(HorizontalSpeed<MaxSpeed)
        HorizontalSpeed += Accel * Time.deltaTime;
    }
    protected virtual void StandBy()
    {
       
        Ray R= new Ray(RaycastEmitter.position,RaycastEmitter.forward);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(R,out hit, SightRange,Layers))
        {
            Invoke("ReadyForCharge", ChargeDelay);
            State = 4;
        }
    }

    private void Stun()
    {
        if (Time.time > Unstuntime)
        {
            transform.Rotate(0, 180, 0);
            State = 2;
        }
    }
   protected virtual void ReadyForCharge()
    {
        anim.SetBool("Charge", true);
        State = 1;
        Stunner.SetActive(true);
    }
    protected override void Death()
    {
        Destroy(gameObject);
    }
}
