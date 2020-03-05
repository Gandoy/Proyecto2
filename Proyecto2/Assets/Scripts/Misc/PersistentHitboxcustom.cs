using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentHitboxcustom : MonoBehaviour
{
    [SerializeField]
    private int dmg;
    private void OnTriggerStay(Collider other)
    {
        Hurtbox Damaged;
        Damaged = other.GetComponent<Hurtbox>();
        Damaged.GetHit(dmg);

    }
}
