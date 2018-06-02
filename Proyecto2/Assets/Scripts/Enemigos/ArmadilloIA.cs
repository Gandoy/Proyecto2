using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloIA : Character {
    [SerializeField]
    private int State;
    [SerializeField]
    private float Gravity;
    private float VerticalForce;
    [SerializeField]
    private float HorizontalSpeed;
    private CharacterController CC;
    private Player PS;
    private void Awake()
    {
       
    }
    private void Start()
    {
        CC = GetComponent<CharacterController>();
      //  if (Player.PlayerSingleton == null)
        //    Debug.Log("es null");
        PS = Player.PlayerSingleton;
    }
    private void Update()
    {
        switch (State)
        {
            case 0:
                {
                    //aca manda la idle animation
                    break;
                }
            case 1:
                {
                    //aca hacelo girar
                    Phy(PS.LeftOrRightFrom(transform.position.z));
                    break;
                }
        }
    }
    private void Phy(int HorizontalDir)
    {
        Vector3 mov = Vector3.zero;
        mov += Vector3.down * -VerticalForce;
        mov += Front * HorizontalDir *HorizontalSpeed;
        CC.Move(mov * Time.deltaTime);
    }
}

