using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Hurtbox Damaged;
        Damaged = other.GetComponent<Hurtbox>();
        Damaged.GetHit(1);
        Destroy(transform.parent.gameObject);
    }
    
}
