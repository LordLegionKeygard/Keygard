using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject _boss;
    public GameObject _bossBackWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _boss.SetActive(true);
            _bossBackWall.SetActive(true);

        }
    }
}
