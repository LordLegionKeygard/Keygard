using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxHealth : MonoBehaviour
{   
    private EnemyLoot _enemyLoot;

    private UnityEngine.Object explosion;
    public AudioSource _boxBreak1;
    public AudioSource _boxBreak2;
    public AudioSource _boxBreak3;

    public float _health = 1f;
    private float _vectorY = 0.5f;


    private void Start()
    {
        _enemyLoot = GetComponent<EnemyLoot>();

        explosion = Resources.Load("BoxExplosion");
    }
    public void TakeDamage(int damage)
    {       
        _health -= damage;
        if (_health <= 0)
        {
            RandomStatePicker();
        }

    }

    private void RandomStatePicker()
    {
        int randomState = Random.Range(0, 3);
        if (randomState == 0)
        {
            _boxBreak1.Play();
        }
        if (randomState == 1)
        {
            _boxBreak2.Play();   
        }
        if (randomState == 2)
        {
            _boxBreak3.Play();
        }
        Die();
    }

    private void Die()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);      

        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y+_vectorY, transform.position.z);

        _enemyLoot.CalculateLoot();

        Destroy(gameObject);
    }
}
