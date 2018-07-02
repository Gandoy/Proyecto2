using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private int PupNumber;
    private void Start()
    {
        if(PowerUpController.instance.CheckPup(PupNumber))
            Destroy(gameObject);
    }
    
        
    

    private void OnTriggerEnter(Collider other)
    {
        PowerUpController.instance.SetPup(PupNumber);
        Destroy(gameObject);
    }
}
