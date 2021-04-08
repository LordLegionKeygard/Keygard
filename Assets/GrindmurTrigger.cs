using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindmurTrigger : MonoBehaviour
{
    public GameObject grindmur;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            grindmur.SetActive(true);
        }
    }
}
