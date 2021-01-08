using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    [SerializeField] private AudioSource mainsound;
    [SerializeField] private AudioSource gameov;
    private void OnEnable()
    {
        mainsound.Stop();
        gameov.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
