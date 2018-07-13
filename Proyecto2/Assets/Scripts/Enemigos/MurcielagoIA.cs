using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurcielagoIA : Character {

    private CharacterController CC;
    private Player PS;
    [SerializeField]
    protected List<Transform> Waypoints;
    protected int CurrentWaypoint;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected RotateModel Rotator;
    private float LastPause;
    [SerializeField]
    private float PauseTime;

    protected override void Death()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (LastPause < Time.time)
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Waypoints[CurrentWaypoint].position) < speed * Time.deltaTime)
        {
            transform.position = Waypoints[CurrentWaypoint].position;
            CurrentWaypoint++;
            CurrentWaypoint = CurrentWaypoint % Waypoints.Count; //aritmetica modular vieja
            LastPause = Time.time + PauseTime;
            Rotator.turnTowards(Waypoints[CurrentWaypoint].position);

        }
    }
}
