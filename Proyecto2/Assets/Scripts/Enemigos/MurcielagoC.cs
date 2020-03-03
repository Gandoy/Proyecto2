using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurcielagoC : MurcielagoIA {

    private bool MoveOut;

    private void Update()
    {
        if (MoveOut)
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Waypoints[CurrentWaypoint].position) < speed * Time.deltaTime)
        {
            transform.position = Waypoints[CurrentWaypoint].position;
            CurrentWaypoint++;
            CurrentWaypoint = CurrentWaypoint % Waypoints.Count; //aritmetica modular vieja
            MoveOut = false;
            Rotator.turnTowards(Waypoints[CurrentWaypoint].position);

        }
    }
    public void Rotate()
    {
        MoveOut = true;
    }
   
}
