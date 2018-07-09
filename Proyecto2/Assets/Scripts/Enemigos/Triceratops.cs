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

    void Start () {

        CC = GetComponent<CharacterController>();
        PS = Player.PlayerSingleton;
    }
    public void Getstunned()
    {
        State = 3;
        Unstuntime = Time.time + StunTime;
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
	}
   private void Charge()
    {
        CC.Move(transform.forward * HorizontalSpeed * Time.deltaTime);
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
        if (Time.time>Unstuntime)
        {
            transform.Rotate(0, 180, 0);
            State = 2;
        }
    }
    private void ReadyForCharge()
    {
        State = 1;
        Stunner.SetActive(true);
    }
}
