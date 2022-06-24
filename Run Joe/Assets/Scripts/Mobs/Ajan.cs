using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Ajan : MonoBehaviour
{
    [SerializeField] private float yurumeHizi,kosmaHizi;
    public Joe joe;
    void Start()
    {
        joe = GameObject.FindGameObjectWithTag("Player").GetComponent<Joe>();
    }

    void Update()
    {
        TakipEt();
    }

    void TakipEt()
    {

    }
}
