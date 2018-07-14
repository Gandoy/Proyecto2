using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour {


    public static BatController instance;
    [SerializeField]
    private int Bats=0;
    [SerializeField]
    private int BatLimit;

    public bool RoomForBats()
    {
        return (Bats < BatLimit);
    }
    public void BatBorn ()
    {
        Bats++;
    }
    public void BatDie()
    {
        Bats--;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
           
    }

}
