using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointRepositioner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(CheckpointFlag.instance!=null)
        if (CheckpointFlag.instance.Level3)
            Player.PlayerSingleton.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
