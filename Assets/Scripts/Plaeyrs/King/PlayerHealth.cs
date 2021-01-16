using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private Animator animator;
    public int health = 6;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite HeartFull;
    public Sprite HeartEmpty;
    public AudioSource PickUp;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {       
        health -= damage;
        animator.SetTrigger("takeDamage");
    
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        gameOverCanvas.SetActive(true);
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

