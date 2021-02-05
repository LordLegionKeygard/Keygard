using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;
    public float TimeToLive = 4f;
    private float angle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
    }

    void Update()
    {
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {        
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
           
        Destroy(gameObject);        
    }
}
