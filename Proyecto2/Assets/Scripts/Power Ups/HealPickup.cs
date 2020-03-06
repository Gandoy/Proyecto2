using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour
{
    [SerializeField]
    private GameObject soundqueue;
    private void OnTriggerEnter(Collider other)
    {
        Player.PlayerSingleton.FullHeal();
        Instantiate(soundqueue, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }
}
