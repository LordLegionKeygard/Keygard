using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePointRotate : MonoBehaviour {

  private float moveInput;
  public bool facingRight = true;
  private Rigidbody2D rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {   
    moveInput = Input.GetAxis("Horizontal");    
      if (facingRight == false && moveInput > 0)
      {
        Flip();
      } 
      else if (facingRight == true && moveInput < 0)
      {
        Flip();
      }
  }

  void Flip()
  {
    facingRight = !facingRight;
    transform.Rotate(0f, 180f, 0f);
  }   
}
