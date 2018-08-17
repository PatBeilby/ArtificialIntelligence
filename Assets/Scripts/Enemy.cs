using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public enum State
    {
        Patrol = 0,
        Seek = 1
    }
    public State currentState = State.Patrol;
    public Transform target;

    public Transform waypointParent;
    public float moveSpeed;
    public float stoppingDistance = 1f;

    // Creates a collection of Transforms
    private Transform[] waypoints;
    private int currentIndex = 1;
    public float seekRadius = 5f;
    // Use this for initialization

    void Patrol()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, point.position);


        if (distance < 2f)
        {
            if (currentIndex < 14)
            {


                //CurrentIndex = CurrentIndex +1
                currentIndex++;
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 1;
                }

            }
        }
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);

        float distToTarget = Vector3.Distance(transform.position, target.position);
        if(distToTarget < seekRadius)
        {
            currentState = State.Seek;
        }
    }

    void Seek()
    {
        // transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);
        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget > seekRadius)
        {
            currentState = State.Seek;
        }
    }
    void Start() {

        // Getting children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                // Patrol state
                Patrol();
                break;
            case State.Seek:
                // Seek state
                Seek();
                break;
            default:
                break;
        }


        Transform point = waypoints[currentIndex];

        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < stoppingDistance)
        {
            if (currentIndex < 14)
            {


                //CurrentIndex = CurrentIndex +1
                currentIndex++;
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 1;
                }

            }
        }
        transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed);
    }

     // Switch current state 
        //if we are in patrol
        // Call patrol()
        //If we are in seek
        //Call Seek()
}
