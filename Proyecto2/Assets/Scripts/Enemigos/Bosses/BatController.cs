using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour {


    public static BatController instance;
    [SerializeField]
    private int Bats=0;
    [SerializeField]
    private int BatLimit;
    private bool Triggered = false;
    [SerializeField]
    private GameObject BigBat;

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
        if (Bats == 0 && !Triggered)
        {
            BigBat.SetActive(true);
            Triggered = true;
        } 
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
