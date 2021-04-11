using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArcherFirePoint : MonoBehaviour
{
    public Archer isFacingRight;

    private void Start()
    {
        isFacingRight = GetComponentInParent<Archer>();
    }

    private void FixedUpdate() 
    {
        if(!isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
        }           
    }
}
