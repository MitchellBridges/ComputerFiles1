using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyChase : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float chaseDistance = 2f;
	Path path;
	int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0, 0.5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }


    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }


    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    //Fixed FrameRate
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
            
        }
        if(currentWaypoint>= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        ChaseTarget();
    }


    void ChaseTarget()
    {
        Vector2 direction = (Vector2)path.vectorPath[currentWaypoint] - rb.position;
        if (direction.magnitude < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        direction.Normalize();
        Vector2 velocity = direction * speed * Time.deltaTime;
        rb.velocity = velocity;
    }
}
