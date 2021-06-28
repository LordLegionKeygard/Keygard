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

    private float timeToDamage = 2f;
    private float damageTime;
    private bool isDamage = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        damageTime = timeToDamage;
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
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

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemyHealth = hitInfo.GetComponent<EnemyHealth>();
        if (enemyHealth != null )
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
        if (gruzeHealth != null  && isDamage)
        {
            gruzeHealth.TakeDamage(damage);
            isDamage = false;
        } 
           
        GrindMur grindmurHealth = hitInfo.GetComponent<GrindMur>();       
        if (grindmurHealth != null  && isDamage)
        {
            grindmurHealth.TakeDamage(damage);
            isDamage = false;
        } 
           
        JesterHealth jesterHealth = hitInfo.GetComponent<JesterHealth>();       
        if (jesterHealth != null)
        {
            jesterHealth.TakeDamage(damage);
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
        if (bromidHealth != null  && isDamage)
        {
            bromidHealth.TakeDamage(damage);
            isDamage = false;
        } 

        BlueSleepHealth sleepHealth = hitInfo.GetComponent<BlueSleepHealth>();
        if (sleepHealth != null)
        {
            sleepHealth.TakeDamage(damage);
        }

        SnailHealth snailHealth = hitInfo.GetComponent<SnailHealth>();
        if (snailHealth != null && isDamage)
        {
            snailHealth.TakeDamage(damage);
            isDamage = false;
        }

        Chest _chest = hitInfo.GetComponent<Chest>();
        if (_chest != null && isDamage)
        {
            _chest.TakeDamage(damage);
            isDamage = false;
        }

        BoxHealth _box = hitInfo.GetComponent<BoxHealth>();
        if(_box != null)
        {
            _box.TakeDamage(damage);
        }

        if(hitInfo.gameObject.CompareTag("Wall") || hitInfo.gameObject.CompareTag("BulletEnemy"))
        {
            Destroy(gameObject);
        }
    }       
}
