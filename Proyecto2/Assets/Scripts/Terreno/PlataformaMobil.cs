using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMobil : MonoBehaviour {

    [SerializeField]
    private List<Transform> Waypoints;
    [SerializeField]
    private int CurrentWaypoint;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float PauseTime;
    private float LastPause;
    [SerializeField]
    MurcielagoC M;
	
	void Update () {
        if(LastPause<Time.time)
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, speed*Time.deltaTime);
        if (Vector3.Distance(transform.position, Waypoints[CurrentWaypoint].position) < speed*Time.deltaTime)
        {
            transform.position = Waypoints[CurrentWaypoint].position;
            CurrentWaypoint++;
            CurrentWaypoint = CurrentWaypoint % Waypoints.Count; //aritmetica modular vieja
            LastPause = Time.time + PauseTime;
            if (M!=null)
            {
                M.Rotate();
            }
           
        }
    }
}
