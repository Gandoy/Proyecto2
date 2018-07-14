using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaBoss3 : PlataformaMobil {

    void Update()
    {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Waypoints[CurrentWaypoint].position) < speed * Time.deltaTime)
        {
            transform.position = Waypoints[CurrentWaypoint].position;
        }
    }
    public void Mov(int C)
    {
        CurrentWaypoint = C;
    }

}
