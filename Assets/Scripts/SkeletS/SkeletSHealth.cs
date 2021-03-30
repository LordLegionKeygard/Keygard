using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletSHealth : MonoBehaviour
{   
    private Animator animator;

    private UnityEngine.Object explosion;
    public SkeletS enemy;
    public GameObject SKELET;

    [Header("Slider")]
    [SerializeField] private float totalHealth = 3f;
    [SerializeField] private Slider healthSlider;
    public GameObject _hiddenSlider;
    public float _health = 3f;


    private void Start()
    {
        _health = totalHealth;
        animator = GetComponent<Animator>();
        enemy = GetComponentInParent<SkeletS>();
        explosion = Resources.Load("Explosion1");
        healthSlider.value = _health / totalHealth;
    }
    public void TakeDamage(int damage)
    {       
        _health -= damage;
        InitHealth(); 
        animator.SetTrigger("takeDamage");
        if (_health <= 0)
        {
            Die();
        }
        if (_health == 1 || _health == 2)
            {
                enemy.StartChasingPlayer();                
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

        Destroy(SKELET);
    }
}
