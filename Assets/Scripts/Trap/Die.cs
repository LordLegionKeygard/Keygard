using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private int damage = 100;
    private float timeToDamage = 1f;

    private float damageTime;
    private bool isDamage = true;
    private Rigidbody2D rb;

    private void Start()
    {
        damageTime = timeToDamage;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!isDamage)
        {
            damageTime -= Time.deltaTime;
            if(damageTime <= 0f)
            {
                isDamage = true;
                damageTime = timeToDamage;
            }          
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if(playerHealth !=null && isDamage)
        {
            playerHealth.TakeDamage(damage);
            isDamage = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)        
    {
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
    }         
}
