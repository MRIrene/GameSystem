using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Practice
{
    public class Enemy : MonoBehaviour
    {

        // declaration of a variable by providing it a name value;
        public enum State
        {
            Patrol = 0,
            Seek = 1
        }

        public NavMeshAgent agent;
        public State currentState = State.Patrol;
        public Transform target; // a way to detect the player
        public float seekRadius = 5f;

        public Transform waypointParent;
        // creates a collection of transforms
        private Transform[] waypoints;
        private int currentIndex = 1;



        //CTRL + M + O (fold code)
        // CTRL + M + P (unfold code)

        // the ememy is following the wave point path
        void Patrol()
        {
            Transform point = waypoints[currentIndex];
            // the distance between the enemy and the current waypoint
            float distance = Vector3.Distance(transform.position, point.position);
            if (distance < .5f)
            {
                // currentIndex = currentIndex + 1
                currentIndex++;
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 1;
                }
            }

            agent.SetDestination(point.position);
            //transform.position = Vector3.MoveTowards(transform.position, point.position, 0.05f);

            float distTotarget = Vector3.Distance(transform.position, target.position);
            if (distTotarget < seekRadius)
            {
                currentState = State.Seek;
            }

        }

        // the enemy is now seeking the target
        void Seek()
        {

            agent.SetDestination(target.position);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, 0.05f);
            float distTotarget = Vector3.Distance(transform.position, target.position);
            if (distTotarget > seekRadius)
            {
                currentState = State.Patrol;
            }
        }


        // Use this for initialization
        void Start()
        {

            //getting children of waypointParent
            waypoints = waypointParent.GetComponentsInChildren<Transform>();

        }

        private void Update()
        {
            //switch current state
            switch (currentState)
            {
                case State.Patrol:
                    Patrol();
                    break;
                case State.Seek:
                    Seek();
                    break;
                default:
                    break;
            }
            //if we are in Patrol
            // Call Patrol()
            // If we are in seek
            // call seek 
        }


    }
}