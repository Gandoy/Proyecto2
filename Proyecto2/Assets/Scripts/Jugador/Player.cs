using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

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
    public static Player PlayerSingleton;
    [SerializeField]
    private float StoneCD;
    private float LastStone=0;
    [SerializeField]
    private AnimatorScript AnimS;
    [SerializeField]
    private string ShootAnim;
    private int CurrentWeapon = 1;

    public void TakeAnyInput(int I)
    {
        if (I < 4) SwitchWeapon(I);
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
    public void SwitchWeapon(int W)
    {
        CurrentWeapon = W;
    }
    protected override void StuffToDoOnAwake()
    {
        HP = MaxHP;
        CC = GetComponent<CharacterController>();
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
        }

        Vector3 mov = Vector3.zero;
        if (Input.GetKeyDown(Jumpbutton) && Jumps > 0)
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
                AnimS.Refresh(true,"Salto");

            }

        }
        VerticalForce -= Gravity;
        if (VerticalForce <= 0 && !ChrouchingJump)
        {
            gameObject.layer = DefaultLayer;
        }
        mov += Vector3.down * -VerticalForce;
        mov += Front * TakeHorizontalInput() * HorizontalSpeed;
        CC.Move(mov * Time.deltaTime);
    }

    private float TakeHorizontalInput()
    {
        float Dir = Input.GetAxis("Horizontal");
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
        return Input.GetKey(Down);
    }
    private bool TakeShootInput()
    {
        return Input.GetKey(Shoot);
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
}
