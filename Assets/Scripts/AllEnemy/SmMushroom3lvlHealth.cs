﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmMushroom3lvlHealth : MonoBehaviour
{ 
    private Animator animator;

    private EnemyLoot _enemyLoot;

    private UnityEngine.Object explosion;
    public SmMushroom3lvl enemy;
    public GameObject ENEMY;

    [Header("Slider")]
    [SerializeField] private float totalHealth = 2f;
    [SerializeField] private Slider healthSlider;
    public GameObject _hiddenSlider;
    public float _health = 2f;

    private float timeToDamage = 0.2f;
    private float damageTime;
    private bool isDamage = true;

    private void Start()
    {
        damageTime = timeToDamage;
        _enemyLoot = GetComponent<EnemyLoot>();
        _health = totalHealth;
        animator = GetComponent<Animator>();
        enemy = GetComponentInParent<SmMushroom3lvl>();
        explosion = Resources.Load("Explosion1");
        healthSlider.value = _health / totalHealth;
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

    public void TakeDamage(int damage)
    {
        if(isDamage)
        {      
            _health -= damage;
            enemy.StartChasingPlayer();
            InitHealth();
            isDamage = false; 
            if (_health <= 0)
            {
                Die();
            }
        }
    }

    private void InitHealth()
    {
        healthSlider.value = _health / totalHealth;
        _hiddenSlider.SetActive(true);
    }

    private void Die()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        _enemyLoot.CalculateLoot();

        Destroy(ENEMY);
    }
}
