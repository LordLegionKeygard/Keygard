using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    private Transform target;
    public float activateDistance = 50f;
    public float attackDistance = 10f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behavior")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;


    [SerializeField] private Animator animator;
    private Path path;
    private int currentWaypoint = 0;
    RaycastHit2D isGrounded;
    Seeker seeker;
    Rigidbody2D rb;
    private Transform playerTransform;
    bool walk = true;
    private  Collider2D boundsCollider;

    [SerializeField] private Transform model;

    public void Start()
    {
        target = GameObject.Find("Ellor").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        boundsCollider = GetComponentInChildren<Collider2D>();

        InvokeRepeating(nameof(UpdatePath), 0f, pathUpdateSeconds);
    }

    private void Update() 
    {
        if(target == null ) return;

        if(Vector2.Distance(transform.position, target.transform.position) < attackDistance)
        {
            animator.SetTrigger("Attack");
        }     
    }

    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }

        if(animator)
        {
            animator.SetBool("Walk", walk);
        } 
    }

    private void UpdatePath()
    {
        if(target == null) return;

        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            walk = true;
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        // Reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        // See if colliding with anything
        
        Vector3 startOffset = model.position - new Vector3(0f, boundsCollider.bounds.extents.y + jumpCheckOffset);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);
        
        // Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        // Jump
        if (jumpEnabled && isGrounded)
        {
            if (direction.y > jumpNodeHeightRequirement)
            {
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }
        }

        // Movement
        rb.AddForce(force);

        // Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Direction Graphics Handling
        if (directionLookEnabled)
        {
            if (rb.velocity.x > 0.05f)
            {
                model.localScale = new Vector3(-1f * Mathf.Abs(model.localScale.x), model.localScale.y, model.localScale.z);
            }
            else if (rb.velocity.x < -0.05f)
            {
                model.localScale = new Vector3(Mathf.Abs(model.localScale.x), model.localScale.y, model.localScale.z);
            }
        }
    }

    private bool TargetInDistance()
    {
        if (target == null)
        {
            return false;
        }
        else
        {
            float distanceToTarget = Vector2.Distance(model.position, target.transform.position);

            bool targetInDistance = distanceToTarget < activateDistance;
            return targetInDistance;
        }

    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private float DistanceToPlayer()
    {
        return playerTransform.position.x - transform.position.x;
    }
}
