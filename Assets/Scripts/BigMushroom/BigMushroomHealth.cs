using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigMushroomHealth : MonoBehaviour
{
    
    private Animator animator;

    private UnityEngine.Object explosion;
    public BigMushroom enemy;
    public GameObject BIG;

    [Header("Slider")]
    [SerializeField] private float totalHealth = 6f;
    [SerializeField] private Slider healthSlider;
    public GameObject _hiddenSlider;
    public float _health = 6f;


    private void Start()
    {
        _health = totalHealth;
        animator = GetComponent<Animator>();
        enemy = GetComponentInParent<BigMushroom>();
        explosion = Resources.Load("Explosion1");
        healthSlider.value = _health / totalHealth;
    }
    public void TakeDamage(int damage)
    {       
        _health -= damage;
        enemy.StartChasingPlayer();
        InitHealth(); 
        animator.SetTrigger("takeDamage");
        if (_health <= 0)
        {
            Die();
        }
    }

    private void InitHealth()
    {   StopAllCoroutines();
        healthSlider.value = _health / totalHealth;
        _hiddenSlider.SetActive(true);

        StartCoroutine(ExecuteAfterTime(5f));
        IEnumerator ExecuteAfterTime(float timeInSec)
        {
        yield return new WaitForSeconds(timeInSec);
        _hiddenSlider.SetActive(false);
        }
    }

    private void Die()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Destroy(BIG);
    }
}
