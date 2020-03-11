using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFlag : MonoBehaviour
{
    public static CheckpointFlag instance;
    // Start is called before the first frame update
    public bool Level3;
    void Start()
    {
        if (instance==null)
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
