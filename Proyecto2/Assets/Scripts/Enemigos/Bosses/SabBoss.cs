using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    private RotateModel Rotator;
    [SerializeField]
    private Animator anim;
    public string Escena;
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
    [SerializeField]
    private float LastJumpPower;
    private float lastairtime;
    private bool LastJump;
    [SerializeField]
    private float LastJumpError;

    public override void GetDamaged(int Damage)
    {
        SoundQueue();
        VisualQueue();
        HP -= Damage; if (HP <= 0&&!DroppedWeaponAlready)
        {
            Instantiate(WeaponPup, WPupSpawnP.position, WPupSpawnP.rotation);
            DroppedWeaponAlready = true;
        }
        if (LastJump)
        {
            Death();
        }
    }
    private void Start()
    {
        P = Player.PlayerSingleton;
    }
    protected override void Death()
    {
        if (!deadalready)
        {
            Instantiate(SFXondeath, transform.position, transform.rotation);
            CancelInvoke();
            Invoke("scenechange", scenedelay);

            Destroy(hitbox);

            deadalready = true;
        }
           
    }
    private void scenechange()
    {
        SceneManager.LoadScene(Escena);

    }
    private void Awake()
    {
        CC = GetComponent<CharacterController>();
        soundQueue = GetComponent<AudioSource>();
        AirTime = (JumpPower / Gravity) * 2;
        lastairtime = (LastJumpPower / Gravity);
    }

    private float VX(float Distance)
    {
        return Distance / AirTime;
    }
    private float LVX (float distance)
    {
        return distance / lastairtime;
    }
    private void Update()
    {
       
        if (!DroppedWeaponAlready)
        {
            if (CC.isGrounded)
            {
                anim.Play("Salto");
                if (P.LeftOrRightFrom(transform.position.z) == -1)
                    Rotator.turnleft();
                else
                    Rotator.turnright();
                float D;
                if (Jumps > 0)
                {
                    D = transform.position.z - Target.position.z;
                    Jumps--;
                }
                else
                {
                    Jumps = MaxJumps;
                    if (P.LeftOrRightFrom(transform.position.z) == -1)
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
            Vector3 mov = new Vector3(0, VForce, vx * -1);
            CC.Move(mov * Time.deltaTime);
        }
        else
        {
            if (CC.isGrounded&&!LastJump)
            {
                anim.Play("Salto");
                if (P.LeftOrRightFrom(transform.position.z) == -1)
                    Rotator.turnleft();
                else
                    Rotator.turnright();
                float D;
                
                
                Jumps = MaxJumps;
                    
                D = transform.position.z - LeftC.position.z;
                    

                

                vx = LVX(D);
                VForce = LastJumpPower;
                Direction = P.LeftOrRightFrom(transform.position.z);
                LastJump = true;
            }
            else
                VForce -= Gravity * Time.deltaTime;

            if (transform.position.z < LastJumpError)
            {
                vx = 0;
            }
            Vector3 mov = new Vector3(0, VForce, vx * -1);
            
            CC.Move(mov * Time.deltaTime);
        }
    }
       
    
}
