using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    private NavMeshAgent carrot;
    private Transform rabbit;
    void Start()
    {
        carrot = GetComponent<NavMeshAgent>();
        rabbit = GameObject.Find("PlayerArmature").transform;
    }

    void Update()
    {
        carrot.SetDestination(rabbit.position);
    }
}
