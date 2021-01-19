using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public Transform objetivo;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(objetivo.position.x - transform.position.x < 1 && objetivo.position.x -transform.position.x > -1
           // && objetivo.position.y - objetivo.position.y < 1 && objetivo.position.y - objetivo.position.y > -1) {
            //agent.SetDestination(objetivo.position);
        //}
    }
}
