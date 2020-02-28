using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    [SerializeField]
    private float OpeningSpeed;
    [SerializeField]
    private float FinalSpeed;
    [SerializeField]
    private float Acceleration;
    [SerializeField]
    private float DeleteTimer;
    private float Spawntime;
    private float Speed;
    

    // Start is called before the first frame update
    void Start()
    {
        Spawntime = Time.time;
        Speed = OpeningSpeed;
    }

    private void Physics()
    {
        if (Speed >= FinalSpeed)
            Speed += Acceleration;
        else if (Speed < FinalSpeed)
            Speed = FinalSpeed;

        transform.Translate(0,Speed * Time.deltaTime,0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > DeleteTimer + Spawntime)
            Destroy(gameObject);
        Physics();
    }
}
