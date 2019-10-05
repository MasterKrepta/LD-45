using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class CatMove : MonoBehaviour, ICanDetect
{
    [SerializeField] Transform Target;
    [SerializeField] float detectRange = 25f;
    [SerializeField] float moveRadius = 35f;
    NavMeshAgent agent;
    public bool Reacting = false;
    [SerializeField] GameObject[] Waypoints;
    
    

    [SerializeField]Transform randPos;

  

    public void Patrol() {
        if (!Reacting) {
            var distToRandomPos = Vector3.Distance(randPos.position, transform.position);
            var DistToPlayer = Vector3.Distance(Target.position, transform.position);

            if (DistToPlayer < detectRange) {
                agent.SetDestination(Target.position);
                print("playerDetected");

            } else {

                agent.SetDestination(randPos.position);
            }

          
        }
        //print($"Remainging distance {agent.remainingDistance}");
        
        if (agent.remainingDistance < 5 || agent.isStopped) {
            
            Reacting = false;
            randPos.position = GetRandomPos();
            agent.SetDestination(randPos.position);
        }

    }

    public Vector3 GetRandomPos() {
        randPos = Waypoints[Random.Range(0, Waypoints.Length)].transform;
        NavMeshHit hit;
        NavMesh.SamplePosition(randPos.position, out hit, moveRadius, 1);
        return hit.position;
    }

    public void React(Transform reactionPoint) {
        print($"oh {reactionPoint.name}... You starteld me");
        Reacting = true;
        randPos = reactionPoint;
        agent.SetDestination(randPos.position);
    }



    // Start is called before the first frame update
    void Start()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        randPos =  Waypoints[ Random.Range(0, Waypoints.Length)].transform;
        if (Target == null) {
            Target = FindObjectOfType<PlayerHealth>().transform;
        }
        agent = GetComponent<NavMeshAgent>();
        randPos.position = GetRandomPos();
        
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

  
}
