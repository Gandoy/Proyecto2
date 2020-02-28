using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Spike;

    public void SpawnSpike(float X)
    {
        Invoke("spawnforinvoke", X);
    }
    private void spawnforinvoke()
    {
        Instantiate(Spike, transform.position, transform.rotation);

    }

}
