using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentHitbox : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        Hurtbox Damaged;
        Damaged = other.GetComponent<Hurtbox>();
        Damaged.GetHit(1);

    }
}
