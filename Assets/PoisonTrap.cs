using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTrap : MonoBehaviour
{
    Animator animator;
    public int poisonDamage = 1;
    private GameObject poisonPanel;

    private float timeToDamage = 3f;
    private float damageTime;
    private bool isDamage = true;

    private void Start()
    {
        poisonPanel = GameObject.Find("/AllCanvas/MobileCanvas/PoisonPanel");
        damageTime = timeToDamage;
        animator = GetComponent<Animator>();
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

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {        
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();

        if (playerHealth != null && isDamage)
        {
            playerHealth.TakePoisonDamage(poisonDamage);
            isDamage = false;
            Die();
        } 
    }   
    

    private void Die()
    {
        StartCoroutine(ExecuteAfterTime(1f));
        IEnumerator ExecuteAfterTime(float timeInSec)
        {
        yield return new WaitForSeconds(timeInSec);
        poisonPanel.SetActive(false);
        }          
    }
}
