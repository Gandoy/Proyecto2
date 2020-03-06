using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private int PupNumber;
    [SerializeField]
    private GameObject soundQueue;
    private void Start()
    {
        if(PowerUpController.instance.CheckPup(PupNumber))
            Destroy(gameObject);
        
    }
    
        
    

    private void OnTriggerEnter(Collider other)
    {
        PowerUpController.instance.SetPup(PupNumber);
        Instantiate(soundQueue, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
