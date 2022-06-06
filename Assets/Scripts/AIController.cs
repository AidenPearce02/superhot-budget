using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Main Camera");
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(Player.transform.position);
    }
}
