using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

//Courtesy of Franquito Laudani & Bradley Sadd - Copyright 2019 All rights reserved.

public class MounstrueControlo : MonoBehaviour
{
    [Tooltip("Radio en el que el enemigo nos puede ver")]
    public float lookRadius = 10f; //Radio en el que el enemigo nos puede ver

    [Tooltip("Tiempo a esperar para patrullar al no poder alcanzar al jugador")]
    public static float waitTime = 10f;
    private float intWaitTime = waitTime;
    public static float patrolWaitTime = 1.5f;

    private float internalptime = patrolWaitTime;

    public bool seeingPlayer = false; //Nos está viendo?
    public bool seenPlayer = false;

    [Tooltip("Puede vernos? (Está para la mecánica del sensor de movimiento)")]
    public bool canSeePlayer = true; //Referenciar como PlayerMngr.instance.monster

    public float patrolSpeed = 1.25f;
    public float chaseSpeed = 2f;

    public float viewConeAngle = 20f;

    private Renderer rend; //Renderizador porque necesitaba hacer debug

    NavMeshAgent agent; //The missile in question
    GameObject player;

    public GameObject[] patrolPoints;
    List<int> patrolorder = new List<int>();
    GameObject target;
    int currentTargetIndex;
    AudioSource ASCR;
    bool sndplaying;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //El agente de navmesh}
        rend = GetComponentInChildren<Renderer>();
        player = PlayerMngr.instance.player;
        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
        ASCR = gameObject.GetComponent<AudioSource>();
        foreach (GameObject pp in patrolPoints)
        {
            int parsed = int.Parse(pp.name);
            patrolorder.Add(parsed);
        }
        print(patrolorder);
        Array.Sort(patrolorder.ToArray(), patrolPoints);
        print(patrolPoints);
        UpdateTarget(0);
        StartPatrol();
    }

    private void Update()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Vector3 playerDirection = player.transform.position - transform.position;
        float angle = Vector3.Angle(playerDirection, transform.forward);

        if (canSeePlayer && DistanceToPlayer <= lookRadius && angle < viewConeAngle)
        {
            seeingPlayer = true;
            seenPlayer = true;
            agent.speed = chaseSpeed;
            agent.SetDestination(player.transform.position);
            rend.material.color = Color.green;
            intWaitTime = waitTime;
        }
        else
        {
            seeingPlayer = false;
           
            if (intWaitTime < 0)
            {
                rend.material.color = Color.yellow;
                agent.speed = patrolSpeed;
                StartPatrol();
                intWaitTime = waitTime;
                seenPlayer = false;
            }
            else if (seenPlayer)
            {
                agent.SetDestination(player.transform.position);
            }
        }

        if (!seeingPlayer && seenPlayer)
        {
            intWaitTime -= Time.deltaTime;
        }

        float DistanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        if (DistanceToTarget <= 1)
        {
            internalptime -= Time.deltaTime;
            if (internalptime < 0)
            {
                NextTarget();
                agent.SetDestination(target.transform.position);
                internalptime = patrolWaitTime;
            }
        }
        if (seeingPlayer || seenPlayer)
        {
            if (!sndplaying)
            {
                ASCR.Play();
                sndplaying = true;
            }
        }
        else if (!seenPlayer || !seeingPlayer)
        {
            ASCR.Stop();
            sndplaying = false;
        }
    }

    void StartPatrol()
    {
        UpdateTarget(currentTargetIndex);
        agent.SetDestination(target.transform.position);
    }

    void UpdateTarget(int Index)
    {
        if (Index > patrolPoints.Length - 1)
        {
            Index = 0;
        }
        target = patrolPoints[Index];
        currentTargetIndex = Index;
    }

    void NextTarget()
    {
        UpdateTarget(currentTargetIndex + 1);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius); //Dibujamos el radio de visibilidad del jugador para poder manejarlo más fácil en el editor
        Gizmos.color = Color.blue;
        if (target != null)
            Gizmos.DrawLine(target.transform.position, target.transform.position + (target.transform.up * 2));
       // if (patrolPoints.Length != 0)
        //{
          //  int count = 0;
           // foreach (GameObject point in patrolPoints)
          //  {
             //   count++;
           //     Handles.Label(point.transform.position, count.ToString());
          //  }
        //}
    }
}
