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
    public float _deathTime;
    private bool _must;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
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
 
        GruzMother gruzeHealth = hitInfo.GetComponent<GruzMother>();       
        if (gruzeHealth != null)
        {
            gruzeHealth.TakeDamage(damage);
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

        Chest _chest = hitInfo.GetComponent<Chest>();
        if (_chest != null)
        {
            _chest.TakeDamage(damage);
        }

        BoxHealth _box = hitInfo.GetComponent<BoxHealth>();
        if(_box != null)
        {
            _box.TakeDamage(damage);
            _must = false;
        }

        if(_must == true)
        {
            StartCoroutine(ExecuteAfterTime(_deathTime));
            IEnumerator ExecuteAfterTime(float timeInSec)
            {
            yield return new WaitForSeconds(timeInSec);
            Die();
            } 
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }         
}
