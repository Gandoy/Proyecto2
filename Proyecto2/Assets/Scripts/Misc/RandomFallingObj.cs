using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFallingObj : MonoBehaviour
{
    [SerializeField]
    private float FallSpd;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, FallSpd * Time.deltaTime, 0);
    }
}
