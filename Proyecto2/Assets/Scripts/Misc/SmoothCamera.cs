using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour

{

    [SerializeField]
    private float SmoothSpeed;
    [SerializeField]
    private Vector3 offset;


    [SerializeField]
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");   
    }

    // Update is called once per frame
    
    void LateUpdate ()
    {
        Vector3 DesiredPosition = offset + Player.transform.position;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);
        transform.position = SmoothedPosition;
    }
}
