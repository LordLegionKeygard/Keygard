using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvas : MonoBehaviour
{
    public GameObject poisonStaff;
    public GameObject iceStaff;
    public GameObject windStaff;
    public GameObject fireStaff;

    public GameObject shopCanvas;

    public void PoisonHandler()
    {
        poisonStaff.SetActive(true);
        iceStaff.SetActive(false);
        windStaff.SetActive(false);
        fireStaff.SetActive(false);
    }

    public void IceHandler()
    {
        poisonStaff.SetActive(false);
        iceStaff.SetActive(true);
        windStaff.SetActive(false);
        fireStaff.SetActive(false);        
    }

    public void WindHandler()
    {
        poisonStaff.SetActive(false);
        iceStaff.SetActive(false);
        windStaff.SetActive(true);
        fireStaff.SetActive(false);        
    }

    public void FireHandler()
    {
        poisonStaff.SetActive(false);
        iceStaff.SetActive(false);
        windStaff.SetActive(false);
        fireStaff.SetActive(true);        
    }

    public void BackHandler()
    {
        shopCanvas.SetActive(false);
    }
}
