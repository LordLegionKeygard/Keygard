using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWall : MonoBehaviour
{

    public AudioSource _kamnepad;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerBullet") || other.gameObject.CompareTag("Player"))
        {
            _kamnepad.Play();
        }

        Destroy(gameObject);
    }  
}
