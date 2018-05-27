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
    private GameObject Stone;
    [SerializeField]
    private Transform StoneOriginPoint;
    private void StopCJ()
    {
        ChrouchingJump = false;
    }
    protected override void StuffToDoOnAwake()
    {
        HP = MaxHP;
        CC = GetComponent<CharacterController>();
    }
    private void Awake()
    {
        StuffToDoOnAwake();
    }
   
   private void Physics()
    {
        if (CC.isGrounded)
        {
            Jumps = MaxJumps;
            VerticalForce = 0;
        }

        Vector3 mov = Vector3.zero;
        if (Input.GetKeyDown(Jumpbutton) && Jumps > 0)
        {
            //aca para bajar plataformas
            if (TakeJumpInput())
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
        return Input.GetAxis("Horizontal");
    }

    private bool TakeJumpInput()
    {
        return Input.GetKey(Down);
    }
    private bool TakeShootInput()
    {
        return Input.GetKeyDown(Shoot);
    }
    private void DoTheShooting()
    {
        Instantiate(Stone, StoneOriginPoint.position, StoneOriginPoint.rotation);
    }
    void Update () {
        Physics();
        if (TakeShootInput()) DoTheShooting();

    }
}
