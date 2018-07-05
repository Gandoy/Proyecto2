using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour {

    public Vector3 LR;
    public Vector3 RR;
	
        public void turnleft()
    {
        transform.rotation = Quaternion.Euler(LR);
    }
    public void turnright()
    {
        transform.rotation = Quaternion.Euler(RR);
    }
    public void turnTowards(Vector3 Here)
    {
        transform.LookAt(Here);
    }
	
}
