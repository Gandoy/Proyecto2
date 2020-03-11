using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCheckpointReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (CheckpointFlag.instance!=null)
        CheckpointFlag.instance.Level3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
