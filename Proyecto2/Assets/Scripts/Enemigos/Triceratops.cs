using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triceratops : Character {


    [SerializeField]
    private int State=2;
    [SerializeField]
    private float Gravity;
    private float VerticalForce;
    [SerializeField]
    private float HorizontalSpeed;
    private CharacterController CC;
    private Player PS;
    [SerializeField]
    private float SightRange;
    [SerializeField]
    private LayerMask Layers;
    [SerializeField]
    private float ChargeDelay;
    [SerializeField]
    private GameObject Stunner;
    [SerializeField]
    private float StunTime;
    private float Unstuntime;
    [SerializeField]
    private Transform RaycastEmitter;
    private Animator anim;
    [SerializeField]
    private float Accel;
    [SerializeField]
    private float MaxSpeed;

    void Start () {

        CC = GetComponent<CharacterController>();
        PS = Player.PlayerSingleton;
        anim = GetComponent<Animator>();
    }
    public void Getstunned()
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
   private void Charge()
    {
        if(HorizontalSpeed<MaxSpeed)
        HorizontalSpeed += Accel * Time.deltaTime;
    }
    private void StandBy()
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
    private void ReadyForCharge()
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
