using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatpfHealth : MonoBehaviour
{
    public int health = 2;    

    private UnityEngine.Object explosion;
    private Batpf enemy;

    private void Start()
    {
        enemy = GetComponent<Batpf>();

        explosion = Resources.Load("Explosion1");
    }
    public void TakeDamage(int damage)
    {       
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        if (health == 1)
            {
                enemy.StartChasingPlayer();                
            }
    }

    private void Die()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Destroy(gameObject);
    }
}
