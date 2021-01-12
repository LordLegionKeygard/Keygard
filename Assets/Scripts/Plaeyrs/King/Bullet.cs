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
           
        Destroy(gameObject);        


        SkeletSHealth skeletHealth = hitInfo.GetComponent<SkeletSHealth>();       
        if (skeletHealth != null)
        {
            skeletHealth.TakeDamage(damage);
        } 
            
        Destroy(gameObject);

        RatHealth ratHealth = hitInfo.GetComponent<RatHealth>();       
        if (ratHealth != null)
        {
            ratHealth.TakeDamage(damage);
        }

        Destroy(gameObject); 
 
        GruzMother gruzeHealth = hitInfo.GetComponent<GruzMother>();       
        if (gruzeHealth != null)
        {
            gruzeHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        BatHealth batHealth = hitInfo.GetComponent<BatHealth>();       
        if (batHealth != null)
        {
            batHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        BatpfHealth batpfHealth = hitInfo.GetComponent<BatpfHealth>();       
        if (batpfHealth != null)
        {
            batpfHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        EyeRockHealth eyerockHealth = hitInfo.GetComponent<EyeRockHealth>();       
        if (eyerockHealth != null)
        {
            eyerockHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);
    }        
}
