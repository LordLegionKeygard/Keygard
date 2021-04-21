using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailSpawner : MonoBehaviour
{
    public GameObject _snail;

    void Start()
    {
        RandomStatePicker();
    }

    void RandomStatePicker()
    {
        int randomState = Random.Range(0, 5);
        if (randomState == 0)
        {                                   
            _snail.SetActive(true);
        }
        if (randomState == 1)
        {
            
        }
        if (randomState == 2)
        {
            
        }
        if (randomState == 3)
        {
            
        }
        if (randomState == 4)
        {
            
        }
    } 


}
