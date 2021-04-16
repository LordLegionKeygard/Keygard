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

    private float timeToDamage = 3f;
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
        if (enemyHealth != null  && isDamage)
        {
            enemyHealth.TakeDamage(damage);
            isDamage = false;
        }

        RangeHealth rangeHealth = hitInfo.GetComponent<RangeHealth>();
        if (rangeHealth != null  && isDamage)
        {
            rangeHealth.TakeDamage(damage);
            isDamage = false;
        }  

        FlyPfHealth flyHealth = hitInfo.GetComponent<FlyPfHealth>();
        if (flyHealth != null  && isDamage)
        {
            flyHealth.TakeDamage(damage);
            isDamage = false;
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
        if (jesterHealth != null  && isDamage)
        {
            jesterHealth.TakeDamage(damage);
            isDamage = false;
        } 
           
        SmMushroom3lvlHealth smmushroom3Health = hitInfo.GetComponent<SmMushroom3lvlHealth>();       
        if (smmushroom3Health != null  && isDamage)
        {
            smmushroom3Health.TakeDamage(damage);
            isDamage = false;
        } 
           
        ArcherHealth archerHealth = hitInfo.GetComponent<ArcherHealth>();       
        if (archerHealth != null  && isDamage)
        {
            archerHealth.TakeDamage(damage);
            isDamage = false;
        } 
           
        Bromid bromidHealth = hitInfo.GetComponent<Bromid>();       
        if (bromidHealth != null  && isDamage)
        {
            bromidHealth.TakeDamage(damage);
            isDamage = false;
        } 

        BlueSleepHealth sleepHealth = hitInfo.GetComponent<BlueSleepHealth>();
        if (sleepHealth != null  && isDamage)
        {
            sleepHealth.TakeDamage(damage);
            isDamage = false;
        }

        Chest _chest = hitInfo.GetComponent<Chest>();
        if (_chest != null  && isDamage)
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
