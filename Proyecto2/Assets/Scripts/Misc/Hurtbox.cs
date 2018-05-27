using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour {
    [SerializeField]
    private Character Char;

  public void GetHit(int damage)
    {
        Char.GetDamaged(damage);
    }
}
