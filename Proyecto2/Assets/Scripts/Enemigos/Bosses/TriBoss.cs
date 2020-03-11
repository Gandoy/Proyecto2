using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TriBoss : Triceratops {

    [SerializeField]
    protected List<Transform> PlacesToTeleport;
    [SerializeField]
    protected float TimeBeforeWalk;
    [SerializeField]
    protected float WalkSpeed;
    [SerializeField]
    protected float WalkTime;
    [SerializeField]
    protected float TimeBeforeCharge;
    public string Escena;
    [SerializeField]
    private int secondPhaseHp;
    [SerializeField]
    private List<SpikeSpawner> spawners;
    private System.Random rand = new System.Random();
    private bool ischarging;
    [SerializeField]
    private float scenedelay;
    [SerializeField]
    private GameObject hitbox;
    private bool deadalready = false;
    [SerializeField]
    private GameObject WeaponPup;
    [SerializeField]
    private Transform WPupSpawnP;
    private bool DroppedWeaponAlready;
    

    protected override void Death()
    {
        if (!deadalready)
        {
            LevelsSaveNLoad.instance.LvlComplete(0);
            Instantiate(SFXondeath, transform.position, transform.rotation);
            CancelInvoke();
            Invoke("scenechange", scenedelay);
            HorizontalSpeed = 0;
            anim.SetBool("Charge", false);
            Destroy(hitbox);
            State = 3;
            deadalready = true;
        }
        
    }
    private void scenechange()
    {
        SceneManager.LoadScene(Escena);

    }

    public virtual void TeleportTo(int index)
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
   
    private void SecondPhase ()
    {
        if (!DroppedWeaponAlready)
        {
            Instantiate(WeaponPup, WPupSpawnP.position, WPupSpawnP.rotation);
            DroppedWeaponAlready = true;
        }
        foreach (SpikeSpawner S in spawners)
        {
            double i = rand.NextDouble();
            double j = rand.Next(0, 3);
            float h = (float)i + (float)j;
            S.SpawnSpike(h);
        }
    }
    void Update()
    {
        switch (State)
        {
            case 1:
                {
                    Charge();
                   
                    if (HP < secondPhaseHp&&!ischarging)
                        SecondPhase();
                    ischarging = true;
                    break;
                }
            case 2:
                {
                    ischarging = false;
                    break;
                }
            case 3:
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
