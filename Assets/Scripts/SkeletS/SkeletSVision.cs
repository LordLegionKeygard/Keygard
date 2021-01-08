using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletSVision : MonoBehaviour
{
    [SerializeField] private GameObject currentHitObject;

    [SerializeField] private float circleRadius;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    private SkeletS enemy;
    private Vector2 origin;
    private Vector2 direction;

    private float currentHitDistance;

    private void Start()
    {
        enemy = GetComponent<SkeletS>();       
    }

    private void Update()
    {
        origin = transform.position;

        if(enemy.IsFacingRight)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
        

        RaycastHit2D hit = Physics2D.CircleCast(origin, circleRadius, direction, maxDistance, layerMask);

        if(hit)
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            if(currentHitObject.CompareTag("Player"))
            {
                enemy.StartChasingPlayer();                
            }
        }else {
            currentHitObject = null;
            currentHitDistance = maxDistance;
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawSphere(origin + direction * currentHitDistance, circleRadius);
    }
}
