using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject keyCanvas;
    public GameObject poisonPanel;
    public GameObject _poisonShield;
    private Animator animator;
    public int health = 6;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite HeartFull;
    public Sprite HeartEmpty;
    public AudioSource PickUp;
    private UnityEngine.Object explosion;
    private UnityEngine.Object poisonExplosion;

    private void Awake()
    {
        explosion = Resources.Load("PlayerDamage");
        poisonExplosion = Resources.Load("PlayerPoisonDamage");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(health >=2)
        _poisonShield.SetActive(false);
    }
    public void TakeDamage(int damage)
    {       
        health -= damage;

        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakePoisonDamage(int poisonDamage)
    {        
        if(health >=2)
        {
            poisonPanel.SetActive(true);
            GameObject posionExplosionRef = (GameObject)Instantiate(poisonExplosion);
            posionExplosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            health-= poisonDamage;
        }
        if(health == 1)
        {
            _poisonShield.SetActive(true);
        }
    }

    private void Die()
    {
        gameOverCanvas.SetActive(true);
        keyCanvas.SetActive(false);
        Destroy(gameObject);      
    }

    private void FixedUpdate()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = HeartFull;
            }
            else
            {
                hearts[i].sprite = HeartEmpty;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Potion"))
        {
            PickUp.Play();
            ChangeHealth(1);
            Destroy(other.gameObject);
        }
    }
    
    public void ChangeHealth(int healthValue)
    {
        health += healthValue;
    }
    
}

