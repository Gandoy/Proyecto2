using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PterodactiloIA : MonoBehaviour {

    private CharacterController CC;
    private Player PS;
    [SerializeField]
    private List<Transform> Waypoints;
    private int CurrentWaypoint;
    [SerializeField]
    private float speed;
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, speed);
        if (Vector3.Distance(transform.position,Waypoints[CurrentWaypoint].position)<speed)
        {
            CurrentWaypoint++;
            CurrentWaypoint = CurrentWaypoint % Waypoints.Count; //aritmetica modular vieja
        }
    }
}
