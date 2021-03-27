using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterHealth : MonoBehaviour
{
    public int health = 3;    

    private UnityEngine.Object explosion;
    private Jester enemy;

    public GameObject Library;
    public GameObject Entrance;

    private void Start()
    {
        enemy = GetComponent<Jester>();
        explosion = Resources.Load("Explosion");
    }
    public void TakeDamage(int damage)
    {       
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        if(health == 2 || health == 1)
            {
            enemy.StartChasingPlayer();           
            }
    }

    private void Die()
    {
        Library.SetActive(false);
        Entrance.SetActive(true);
        
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Destroy(gameObject);
    }
}
