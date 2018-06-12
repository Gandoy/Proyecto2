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
    private KeyCode Shoot;
    [SerializeField]
    private Vector3 CamLimit;
    [SerializeField]
    private Vector3 OriginalCamPos;
    [SerializeField]
    private float Speed;

    private void MoveCamUp()
    {
        transform.localPosition = OriginalCamPos;
    }
    private void MoveCamDown()
    {
        if (transform.localPosition.y > CamLimit.y)
            transform.Translate(0, -1 * Time.deltaTime, 0,Space.Self);
        else
            transform.localPosition=CamLimit;
    } 
	void Update () {
		if (Input.GetKey(Down)&&!Input.GetKey(Shoot))
        {
            CurrentHold += Speed * Time.deltaTime;
        }
        else
        {
            CurrentHold = 0;
            if (transform.localPosition!=OriginalCamPos)
            {
                Debug.Log("entroAUp");
                MoveCamUp();
                  }
        }
        if (CurrentHold>HoldTime)
        {
            MoveCamDown();
        }
	}
}
