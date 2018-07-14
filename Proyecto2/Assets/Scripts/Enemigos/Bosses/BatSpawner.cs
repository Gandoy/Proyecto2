using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject Bat;
    [SerializeField]
    private float CD;
    private float LastSpawn;
    private List<Transform> W;
    private PteBoss Sc;
    [SerializeField]
    private BatController BC;
    // Update is called once per frame
    private void Start()
    {
      
            Sc = GetComponent<PteBoss>();
        W = Sc.Waypoints;
    }
    void Update () {
        if (Time.time > LastSpawn && BC.RoomForBats()) 
        {
            BC.BatBorn();
            LastSpawn = Time.time + CD;
          GameObject B= Instantiate(Bat, transform.position, transform.rotation);
            MurcielagoIA S = B.GetComponent<MurcielagoIA>();
            S.Waypoints = W;
            S.CurrentWaypoint = Sc.CurrentWaypoint - 1;
            if(S.CurrentWaypoint<0)
            S.CurrentWaypoint  = S.Waypoints.Count -1;


        }
    }
}
