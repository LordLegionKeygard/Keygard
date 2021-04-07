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
        Destroy(gameObject);

        EnemyHealth enemyHealth = hitInfo.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        RangeHealth rangeHealth = hitInfo.GetComponent<RangeHealth>();
        if (rangeHealth != null)
        {
            rangeHealth.TakeDamage(damage);
        }  

        FlyPfHealth flyHealth = hitInfo.GetComponent<FlyPfHealth>();
        if (flyHealth != null)
        {
            flyHealth.TakeDamage(damage);
        }         
 
        GruzMother gruzeHealth = hitInfo.GetComponent<GruzMother>();       
        if (gruzeHealth != null)
        {
            gruzeHealth.TakeDamage(damage);
        } 

        EyeRockHealth eyerockHealth = hitInfo.GetComponent<EyeRockHealth>();       
        if (eyerockHealth != null)
        {
            eyerockHealth.TakeDamage(damage);
        } 
           
        SkeletRMageHealth skeletrmagHealth = hitInfo.GetComponent<SkeletRMageHealth>();       
        if (skeletrmagHealth != null)
        {
            skeletrmagHealth.TakeDamage(damage);
        } 

        SmallRockHealth smallrockHealth = hitInfo.GetComponent<SmallRockHealth>();       
        if (smallrockHealth != null)
        {
            smallrockHealth.TakeDamage(damage);
        } 
           
        AxeDemonHealth axedemonHealth = hitInfo.GetComponent<AxeDemonHealth>();       
        if (axedemonHealth != null)
        {
            axedemonHealth.TakeDamage(damage);
        } 
           
        GrindMur grindmurHealth = hitInfo.GetComponent<GrindMur>();       
        if (grindmurHealth != null)
        {
            grindmurHealth.TakeDamage(damage);
        } 
           
        JesterHealth jesterHealth = hitInfo.GetComponent<JesterHealth>();       
        if (jesterHealth != null)
        {
            jesterHealth.TakeDamage(damage);
        } 
           
        GoblinHealth goblinHealth = hitInfo.GetComponent<GoblinHealth>();       
        if (goblinHealth != null)
        {
            goblinHealth.TakeDamage(damage);
        } 
           
        SmMushroom3lvlHealth smmushroom3Health = hitInfo.GetComponent<SmMushroom3lvlHealth>();       
        if (smmushroom3Health != null)
        {
            smmushroom3Health.TakeDamage(damage);
        } 
           
        ArcherHealth archerHealth = hitInfo.GetComponent<ArcherHealth>();       
        if (archerHealth != null)
        {
            archerHealth.TakeDamage(damage);
        } 
           
        Bromid bromidHealth = hitInfo.GetComponent<Bromid>();       
        if (bromidHealth != null)
        {
            bromidHealth.TakeDamage(damage);
        } 

        BlueSleepHealth sleepHealth = hitInfo.GetComponent<BlueSleepHealth>();
        if (sleepHealth != null)
        {
            sleepHealth.TakeDamage(damage);
        }

        Chest chest = hitInfo.GetComponent<Chest>();
        if (chest != null)
        {
            chest.TakeDamage(damage);
        }
    }        
}
