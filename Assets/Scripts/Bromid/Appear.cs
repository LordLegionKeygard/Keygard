using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject Bromid;
    public GameObject BromidPortal;

    void OnTriggerEnter2D(Collider2D other)
    {
        Bromid.SetActive(true);
        BromidPortal.SetActive(true);
    }
}
