using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private float HoldTime;
    private float CurrentHold;
    [SerializeField]
    private KeyCode Down;
    [SerializeField]
    private Vector3 CamLimit;
    [SerializeField]
    private Vector3 OriginalCamPos;

    private void MoveCamUp()
    {
       // transform.position = OriginalCamPos;
    }
    private void MoveCamDown()
    {
        if (transform.position.y > CamLimit.y)
            transform.Translate(0, -1 * Time.deltaTime, 0);
        else
            transform.position=CamLimit;
    } 
	void Update () {
		if (Input.GetKey(Down))
        {
            CurrentHold += 1 * Time.deltaTime;
        }
        else
        {
            CurrentHold = 0;
           /* if (transform.position!=OriginalCamPos)
            {
                Debug.Log("entroAUp");
                MoveCamUp();
                  }*/
        }
        if (CurrentHold>HoldTime)
        {
            //MoveCamDown();
        }
	}
}
