using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDeEnemigosPorTrigger : MonoBehaviour {

    [SerializeField]
    private List<GameObject> Enemies;

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject G in Enemies)
        {
            G.SetActive(true);
        }
        Destroy(gameObject);
    }
}
