using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    private bool isFacingRight;

    public bool IsFacingRight
    {
        get => isFacingRight;
    }

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
            Flip();

        }
        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
            Flip();
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    } 

}
