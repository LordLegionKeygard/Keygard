using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPlatform : MonoBehaviour
{
    public GameObject _bigPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _bigPlatform.SetActive(true);            
        }
    }
}
