using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    Animator animator;
    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;
    public float TimeToLive = 4f;


    // Start is called before the first frame update
    private void Start()
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

        SkeletRMageHealth skeletrmagHealth = hitInfo.GetComponent<SkeletRMageHealth>();       
        if (skeletrmagHealth != null)
        {
            skeletrmagHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        BigMushroomHealth bigmushroomHealth = hitInfo.GetComponent<BigMushroomHealth>();       
        if (bigmushroomHealth != null)
        {
            bigmushroomHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);
        
        SmallRockHealth smallrockHealth = hitInfo.GetComponent<SmallRockHealth>();       
        if (smallrockHealth != null)
        {
            smallrockHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        AxeDemonHealth axedemonHealth = hitInfo.GetComponent<AxeDemonHealth>();       
        if (axedemonHealth != null)
        {
            axedemonHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        GrindMur grindmurHealth = hitInfo.GetComponent<GrindMur>();       
        if (grindmurHealth != null)
        {
            grindmurHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        JesterHealth jesterHealth = hitInfo.GetComponent<JesterHealth>();       
        if (jesterHealth != null)
        {
            jesterHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        GoblinHealth goblinHealth = hitInfo.GetComponent<GoblinHealth>();       
        if (goblinHealth != null)
        {
            goblinHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        SmMushroom3lvlHealth smmushroom3Health = hitInfo.GetComponent<SmMushroom3lvlHealth>();       
        if (smmushroom3Health != null)
        {
            smmushroom3Health.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        ArcherHealth archerHealth = hitInfo.GetComponent<ArcherHealth>();       
        if (archerHealth != null)
        {
            archerHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);

        Bromid bromidHealth = hitInfo.GetComponent<Bromid>();       
        if (bromidHealth != null)
        {
            bromidHealth.TakeDamage(damage);
        } 
           
        Destroy(gameObject);
    }    
}
