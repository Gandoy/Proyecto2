using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Spike;

    public void SpawnSpike()
    {
        Instantiate(Spike, transform.position, transform.rotation);
    }

}
