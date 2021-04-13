using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform3pos : MonoBehaviour
{
    public Transform pos1, pos2, pos3, pos4;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
    }

    void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nextPos = pos3.position;
        }
        if(transform.position == pos3.position)
        {
            nextPos = pos4.position;
        }
        if(transform.position == pos4.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
        Gizmos.DrawLine(pos2.position, pos3.position);
        Gizmos.DrawLine(pos3.position, pos4.position);
        Gizmos.DrawLine(pos4.position, pos1.position);        
    }

}
