using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUp : MonoBehaviour
{
    [SerializeField]
    private GameObject SoundQueue;
    [SerializeField]
    private int WpnNumber;
    private void Start()
    {
        if (PowerUpController.instance.CheckWpn(WpnNumber))
            Destroy(transform.parent.gameObject);
    }




    private void OnTriggerEnter(Collider other)
    {
        LitMeUp.instance.Lit();
        Instantiate(SoundQueue, transform.position, transform.rotation);
        Player.PlayerSingleton.TurnWpnOn(WpnNumber);
        Destroy(transform.parent.gameObject);
    }
}
