﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PteBoss : MurcielagoIA {

    [SerializeField]
    private List<float> Speeds;
    [SerializeField]
    private List<PlataformaBoss3> Plats;
    [SerializeField]
    private List<int> PlatTargets;
    public string Escena;
    [SerializeField]
    private GameObject Projectile;
    [SerializeField]
    private List <int> StoneDroppingWaypoints;
    [SerializeField]
    private float ProjectileCD;
    private float lastProjectileFired;
    [SerializeField]
    private List<int> WaypointsToTurnLeft;
    [SerializeField]
    private List<int> WaypointsToTurnRight;
    [SerializeField]
    private Transform DropSpot;

    private void DropStone()
    {
        if (StoneDroppingWaypoints.Contains(CurrentWaypoint) && ProjectileCD + lastProjectileFired < Time.time)
        {
            Instantiate(Projectile, DropSpot.position, DropSpot.rotation);
            lastProjectileFired = Time.time;
        }
           
    }

    private void Update()
    {
        if (LastPause < Time.time)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, speed * Time.deltaTime);
            DropStone();
        }
        if (Vector3.Distance(transform.position, Waypoints[CurrentWaypoint].position) < speed * Time.deltaTime)
        {
            transform.position = Waypoints[CurrentWaypoint].position;
            CurrentWaypoint++;
            CurrentWaypoint = CurrentWaypoint % Waypoints.Count; //aritmetica modular vieja
            speed = Speeds[CurrentWaypoint];
            if (Plats[CurrentWaypoint] != null) 
            Plats[CurrentWaypoint].Mov(PlatTargets[CurrentWaypoint]);
            // Rotator.turnTowards(Waypoints[CurrentWaypoint].position);
            
            if (WaypointsToTurnLeft.Contains(CurrentWaypoint)) Rotator.turnleft();
            if (WaypointsToTurnRight.Contains(CurrentWaypoint)) Rotator.turnright();

            LastPause = Time.time + PauseTime;
            //Rotator.turnTowards(Waypoints[CurrentWaypoint].position);

        }
    }
    protected override void Death()
    {
        Instantiate(SFXondeath, transform.position, transform.rotation);
        SceneManager.LoadScene(Escena);
    }
}
