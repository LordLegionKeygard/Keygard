using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Animator animator;
    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;
    public float TimeToLive = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {        
        GolemHealth enemyHealth = hitInfo.GetComponent<GolemHealth>();       
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        } 
 
        Debug.Log(hitInfo.name);             
        Destroy(gameObject);
               
        SkeletSHealth skeletHealth = hitInfo.GetComponent<SkeletSHealth>();       
        if (skeletHealth != null)
        {
            skeletHealth.TakeDamage(damage);
        } 
 
        Debug.Log(hitInfo.name);             
        Destroy(gameObject);

        RatHealth ratHealth = hitInfo.GetComponent<RatHealth>();       
        if (ratHealth != null)
        {
            ratHealth.TakeDamage(damage);
        } 
 
        Debug.Log(hitInfo.name);             
        Destroy(gameObject);

        BatHealth batHealth = hitInfo.GetComponent<BatHealth>();       
        if (batHealth != null)
        {
            batHealth.TakeDamage(damage);
        } 
 
        Debug.Log(hitInfo.name);             
        Destroy(gameObject);

        BatpfHealth batpfHealth = hitInfo.GetComponent<BatpfHealth>();       
        if (batpfHealth != null)
        {
            batpfHealth.TakeDamage(damage);
        } 
 
        Debug.Log(hitInfo.name);             
        Destroy(gameObject);

        GruzMother gruzeHealth = hitInfo.GetComponent<GruzMother>();       
        if (gruzeHealth != null)
        {
            gruzeHealth.TakeDamage(damage);
        } 
 
        Debug.Log(hitInfo.name);             
        Destroy(gameObject);
    } 

    
        
}
