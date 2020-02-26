using System.Collections;
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
    
    
    private void Update()
    {
        if (LastPause < Time.time)
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[CurrentWaypoint].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, Waypoints[CurrentWaypoint].position) < speed * Time.deltaTime)
        {
            transform.position = Waypoints[CurrentWaypoint].position;
            CurrentWaypoint++;
            CurrentWaypoint = CurrentWaypoint % Waypoints.Count; //aritmetica modular vieja
            speed = Speeds[CurrentWaypoint];
            if (Plats[CurrentWaypoint] != null) 
            Plats[CurrentWaypoint].Mov(PlatTargets[CurrentWaypoint]);
            // Rotator.turnTowards(Waypoints[CurrentWaypoint].position);
            //fix para la rotacion del boss, hardcodie en que waypoints rota<--------
            if (CurrentWaypoint == 1) Rotator.turnleft();
            if (CurrentWaypoint == 6) Rotator.turnright();
           //fin del fix, parametrizar esta mierda si algun dia hay que fixxearlo, programe esto a las 3 am, no me juzgues.
            LastPause = Time.time + PauseTime;
            //Rotator.turnTowards(Waypoints[CurrentWaypoint].position);

        }
    }
    protected override void Death()
    {
        SceneManager.LoadScene(Escena);
    }
}
