using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{   
    private Animator animator;

    private UnityEngine.Object explosion;
    public Enemy enemy;
    public GameObject ENEMY;

    [Header("Slider")]
    [SerializeField] private float totalHealth = 2f;
    [SerializeField] private Slider healthSlider;
    public GameObject _hiddenSlider;
    public float _health = 2f;


    private void Start()
    {
        _health = totalHealth;
        animator = GetComponent<Animator>();
        enemy = GetComponentInParent<Enemy>();
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
    {
        StopAllCoroutines();
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

        Destroy(ENEMY);
    }
}
