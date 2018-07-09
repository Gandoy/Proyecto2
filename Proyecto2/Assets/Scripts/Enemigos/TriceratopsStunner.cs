using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriceratopsStunner : MonoBehaviour {


    [SerializeField]
    private Triceratops Tri;

    private void OnTriggerEnter(Collider other)
    {
        Tri.Getstunned();
        gameObject.SetActive(false);
    }
}
