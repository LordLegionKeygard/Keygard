using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;
    public float TimeToLive = 0.5f;


    // Start is called before the first frame update
    private void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {        
        fourHealth enemyHealth = hitInfo.GetComponent<fourHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
 
        Debug.Log(hitInfo.name);             
        Destroy(gameObject);        


        threeHealth skeletHealth = hitInfo.GetComponent<threeHealth>();       
        if (skeletHealth != null)
        {
            skeletHealth.TakeDamage(damage);
        } 
 
        Debug.Log(hitInfo.name);             
        Destroy(gameObject);

        twoHealth ratHealth = hitInfo.GetComponent<twoHealth>();       
        if (ratHealth != null)
        {
            ratHealth.TakeDamage(damage);
        } 
 
        GruzMother gruzeHealth = hitInfo.GetComponent<GruzMother>();       
        if (gruzeHealth != null)
        {
            gruzeHealth.TakeDamage(damage);
        } 
 
        Debug.Log(hitInfo.name);             
        Destroy(gameObject);
    }    
}
