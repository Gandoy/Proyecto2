using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour {
    public KeyCode Left;
    public KeyCode Right;
    public Vector3 LR;
    public Vector3 RR;
	
	void Update () {
        if (Input.GetKeyDown(Left))
            transform.rotation = Quaternion.Euler(LR);
        if (Input.GetKeyDown(Right))
            transform.rotation = Quaternion.Euler(RR);


	}
}
