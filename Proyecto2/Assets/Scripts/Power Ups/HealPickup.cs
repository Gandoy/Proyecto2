using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player.PlayerSingleton.FullHeal();
        Destroy(transform.parent.gameObject);
    }
}
