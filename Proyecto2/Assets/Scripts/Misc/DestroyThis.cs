using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour {

    [SerializeField]
    private float TimeBeforeDestroy;

    private void Awake()
    {
        Invoke("Banish", TimeBeforeDestroy);
    }
    private void Banish()
    {
        Destroy(gameObject);
    }

}
