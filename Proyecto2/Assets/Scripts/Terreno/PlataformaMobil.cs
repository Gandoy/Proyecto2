using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMobil : MonoBehaviour {

    [SerializeField]
    protected List<Transform> Waypoints;
    [SerializeField]
    protected int CurrentWaypoint;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float PauseTime;
    protected float LastPause;
    [SerializeField]
    protected MurcielagoC M;
	
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
    
   /* private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colisiono");
       // collision.collider.transform.SetParent(transform);
        collision.gameObject.transform.SetParent(transform);
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("descolisiono");
        //collision.collider.transform.SetParent(null);
        collision.gameObject.transform.SetParent(null);

    }*/
     void OnTriggerEnter(Collider collision)
    {
        Debug.Log("colisiono");
        // collision.collider.transform.SetParent(transform);
        collision.gameObject.transform.SetParent(transform);
    }
     void OnTriggerExit(Collider collision)
    {
        Debug.Log("descolisiono");
        //collision.collider.transform.SetParent(null);
        collision.gameObject.transform.SetParent(null);

    }

}
