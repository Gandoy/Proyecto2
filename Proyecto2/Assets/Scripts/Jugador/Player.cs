using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : Character {
    [SerializeField]
    private int BaseHP;
    [SerializeField]
    private float HorizontalSpeed;
    private CharacterController CC;
    [SerializeField]
    private float Gravity;
    [SerializeField]
    private float JumpSpeed;
    private float VerticalForce;
    [SerializeField]
    private int MaxJumps;
    private int Jumps;
    [SerializeField]
    private KeyCode Jumpbutton;
    [SerializeField]
    private int DefaultLayer;
    [SerializeField]
    private int AcrossPlatformsLayer;
    [SerializeField]
    private KeyCode Down;
    private bool ChrouchingJump;
    [SerializeField]
    private float CJDuration;
    [SerializeField]
    private KeyCode Shoot;
    [SerializeField]
    private List<GameObject> Projectiles;
    [SerializeField]
    private Transform StoneOriginPoint;
    [SerializeField]
    private float MinDistToStopForEnemies;
    [SerializeField]
    private float MinVDistToStopForEnemies;
    public static Player PlayerSingleton;
    [SerializeField]
    private float StoneCD;
    private float LastStone=0;
    [SerializeField]
    private AnimatorScript AnimS;
    [SerializeField]
    private string ShootAnim;
    [SerializeField]
    private float InvuAfterDmg;
    private bool IsHittable = true;
    private int CurrentWeapon = 0;
    private bool WallJump = true;
    private bool UsedWJ = false;
    [SerializeField]
    private bool Wall = false;
    private Vector3 hitNormal;
    [SerializeField]
    private float slopeLimit;
    [SerializeField]
    private float slideFriction;
    private bool isGrounded;
    [SerializeField]
    private float slideMultiplier;
    [SerializeField]
    private bool ApplySlide;
    [SerializeField]
    private bool[] weapons = new bool[3];
    [SerializeField]
    private List<Image> Healthbars;

    public void SetWpns(bool[]Wpns)
    {
        weapons = Wpns;
    }
    public void TurnWpnOn(int Windex)
    {
        weapons[Windex] = true;
    }
    public override void GetDamaged(int Damage)
    {
        if (IsHittable)
        {
            HP -= Damage;
            IsHittable = false;
            Invoke("StopBeingImmune", InvuAfterDmg);
            foreach (Image I in Healthbars)
            {
                
                I.fillAmount = (float)HP/(float)MaxHP;
            }
        }
        
    }
    private void StopBeingImmune()
    {
        IsHittable = true;
    }

    public void TakeAnyInput(int I)
    {
        if (I < 4&&weapons[I]) SwitchWeapon(I);
    }
    public void SetMaxHP(int value)
    {
        MaxHP = BaseHP + value;
        HP = MaxHP;
    }

    private void StopCJ()
    {
        ChrouchingJump = false;
    }
    public int LeftOrRightFrom(float here)
    {
        if (Mathf.Abs(here - transform.position.z) < MinDistToStopForEnemies)
            return 0;
        if (here > transform.position.z)
            return -1;   
        return 1;
    }
    public float ExactLeftOrRIght(float here)
    {
        return transform.position.z - here;
    }
    public int UpOrDown(float here)
    {
        if (Mathf.Abs(here - transform.position.y) < MinVDistToStopForEnemies)
            return 0;
        if (here > transform.position.y)
            return -1;
        return 1;
    }
    public void SwitchWeapon(int W)
    {
        CurrentWeapon = W;
    }
    protected override void StuffToDoOnAwake()
    {
        HP = MaxHP;
        CC = GetComponent<CharacterController>();
        soundQueue = GetComponent<AudioSource>();
    }
    private void Awake()
    {
        if (PlayerSingleton!=null)
        {
            Debug.Log("hay 2 jugadores, ojo");
                }
        else
        {
            Debug.Log("entro el singleton");
            PlayerSingleton = this;
        }
        StuffToDoOnAwake();
    }
   
   private void Physics()
    {
        if (CC.isGrounded)
        {
            Jumps = MaxJumps;
            VerticalForce = 0;
            AnimS.Refresh(false, "Salto");
            UsedWJ = false;
        }

        Vector3 mov = Vector3.zero;
        if (Input.GetKeyDown(Jumpbutton)||FlynnInput.instance.JumpDown)
            
        {
            if (Jumps > 0)
            {
                //aca para bajar plataformas
                if (TakeSlideInput())
                {
                    gameObject.layer = AcrossPlatformsLayer;
                    ChrouchingJump = true;
                    Invoke("StopCJ", CJDuration);
                }
                else
                {
                    VerticalForce += JumpSpeed;
                    Jumps--;
                    gameObject.layer = AcrossPlatformsLayer;
                    AnimS.Refresh(true, "Salto");
                }
            }
            else if (WallJump&&Wall&&!UsedWJ)
            {

                VerticalForce = JumpSpeed;
                gameObject.layer = AcrossPlatformsLayer;
                AnimS.Refresh(true, "Salto");
                UsedWJ = true;
            }
           

        }

       if (Time.timeScale!=0f) VerticalForce -= Gravity;
        if (VerticalForce <= 0 && !ChrouchingJump)
        {
            gameObject.layer = DefaultLayer;
        }
        mov += Vector3.down * -VerticalForce;
        mov += Front * TakeHorizontalInput() * HorizontalSpeed;
        if (!isGrounded&&ApplySlide)
        {
            mov.z += (1f - hitNormal.y) * hitNormal.z * (1f - slideFriction)*slideMultiplier;
        }
        CC.Move(mov * Time.deltaTime);
        isGrounded = (Vector3.Angle(Vector3.up, hitNormal) <= slopeLimit);
       
    }

    private float TakeHorizontalInput()
    {
        float Dir = Input.GetAxis("Horizontal");
        if (FlynnInput.instance.RightDown)
            Dir = 1;
        else if (FlynnInput.instance.LeftDown)
            Dir = -1;
        if (Dir != 0)
        {
            AnimS.Refresh(true, "Caminata");
        }
        else
            AnimS.Refresh(false, "Caminata");
        return Dir;
    }

    private bool TakeSlideInput()
    {
        return (Input.GetKey(Down)||FlynnInput.instance.DownDown);
    }
    private bool TakeShootInput()
    {
        return (Input.GetKey(Shoot)||FlynnInput.instance.ShootDown);
    }
    private void DoTheShooting()
    {
        LastStone = Time.time;
        Instantiate(Projectiles[CurrentWeapon], StoneOriginPoint.position, StoneOriginPoint.rotation);

        AnimS.PlayAnim(ShootAnim);
    }
    void Update () {
        Physics();
        if (TakeShootInput()&&Time.time>LastStone+StoneCD) DoTheShooting();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!CC.isGrounded)
            Wall = true;
        else
            Wall = false;
        hitNormal = hit.normal;
    }
  

}
