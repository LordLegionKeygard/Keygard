using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    [SerializeField] private AudioSource mainsound;
    [SerializeField] private AudioSource gameov;
    [SerializeField] private AudioSource BossMusic;    
    private void OnEnable()
    {
        gameov.Play();
        mainsound.Stop();
        BossMusic.Stop();
    }

    void Update()
    {
        UnityEngine.Cursor.visible = true;        
    }
}
