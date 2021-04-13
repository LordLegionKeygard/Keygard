using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTraps : MonoBehaviour
{
    public GameObject _leverNewPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _leverNewPlatform.SetActive(true);
        }
    }
}
