using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Ajan : MonoBehaviour
{
    [SerializeField] private float yurumeHizi,kosmaHizi;
    Joe joe;
    NavMeshAgent ajan;
    void Start()
    {
        ajan = GetComponent<NavMeshAgent>();
        joe = GameObject.FindGameObjectWithTag("Player").GetComponent<Joe>();

        ajan.updateRotation = false;
        ajan.updateUpAxis = false;
    }

    void Update()
    {
        TakipEt();
    }

    void TakipEt()
    {
        ajan.destination = joe.gameObject.transform.position;
        ajan.isStopped = false;
        if (joe.kosuyormu)
        {
            ajan.speed = yurumeHizi;
        }
        else
        {
            ajan.speed = kosmaHizi;
        }
    }
}
