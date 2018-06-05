using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipStoneOP : MonoBehaviour {
    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode Right;
    [SerializeField]
    private KeyCode shoot;
    private bool isRight;
	void Update () {
        if (isRight)
        {
if (Input.GetKey(Right)&&!Input.GetKey(shoot))
        {
            Debug.Log("giro<-");
            isRight = false;
            transform.Rotate(0, 180, 0);
        }
        }
		
        else

       {
 if (Input.GetKey(left)&&!Input.GetKey(shoot))
        {
            Debug.Log("giro->");
            isRight = true;
            transform.Rotate(0, 180, 0);
        }
       }
       
	}
}
