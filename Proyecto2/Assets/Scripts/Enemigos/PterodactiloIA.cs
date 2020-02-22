using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PterodactiloIA : Character {

    private CharacterController CC;
    private Player PS;
    [SerializeField]
    private List<Transform> Waypoints;
    private int CurrentWaypoint;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject Projectile;
    [SerializeField]
    private Transform DropSpot;
    [SerializeField]
    private float AttackCD;
    private float LastAttack;
    [SerializeField]
    private float Prescision;
    [SerializeField]
    private RotateModel Rotator;

    protected override void Death()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, speed*Time.deltaTime);
        if (Vector3.Distance(transform.position,Waypoints[CurrentWaypoint].position)<speed*Time.deltaTime)
        {
            CurrentWaypoint++;
            CurrentWaypoint = CurrentWaypoint % Waypoints.Count; //aritmetica modular vieja
            Rotator.turnTowards(Waypoints[CurrentWaypoint].position);
        }
        if (Time.time>AttackCD+LastAttack)
        {
            Debug.Log("entroCD");
            if (Mathf.Abs(Player.PlayerSingleton.ExactLeftOrRIght(DropSpot.transform.position.z))
                <Prescision )
            {
                Debug.Log("entrohorizontal" +
                    Mathf.Abs(Player.PlayerSingleton.ExactLeftOrRIght(DropSpot.transform.position.z)));
                if (Player.PlayerSingleton.UpOrDown(DropSpot.transform.position.y) == -1)
                {
                    Debug.Log("entroVertical");
                    LastAttack = Time.time;
                    Instantiate(Projectile, DropSpot.position, DropSpot.rotation);
                }
            }
        }
       
    }
}
