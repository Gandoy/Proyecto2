using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTossed : MonoBehaviour {

    [SerializeField]
    private Vector3 Force;
    [SerializeField]
    private float Gravity;
    [SerializeField]
    private float MaxFallSpeed;
    private void Physics()
    {
       if (Force.y>=MaxFallSpeed)
        Force.y += Gravity;

        transform.Translate(Force*Time.deltaTime);
    }

    private void Update()
    {
        Physics();
    }

}
