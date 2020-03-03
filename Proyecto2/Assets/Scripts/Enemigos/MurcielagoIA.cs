using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurcielagoIA : Character {

    protected CharacterController CC;
    protected Player PS;

    public List<Transform> Waypoints;
    public int CurrentWaypoint;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected RotateModel Rotator;
    protected float LastPause;
    [SerializeField]
    protected float PauseTime;

    protected override void Death()
    {
        if(BatController.instance!=null)
        BatController.instance.BatDie();
        Instantiate(SFXondeath, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (LastPause < Time.time)
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Waypoints[CurrentWaypoint].position) < speed * Time.deltaTime)
        {
            transform.position = Waypoints[CurrentWaypoint].position;
            CurrentWaypoint--;
            if (CurrentWaypoint < 0)
                CurrentWaypoint = Waypoints.Count -1;
            LastPause = Time.time + PauseTime;
            Rotator.turnTowards(Waypoints[CurrentWaypoint].position);

        }
    }
}
